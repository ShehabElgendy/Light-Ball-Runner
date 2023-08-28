using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public static AdManager instance;

    private GameOverController gameOverController;

    private ScoreController scoreController;

    private ButtonTimer timer;

    [SerializeField]
    private bool testMode = true;

#if UNITY_ANDROID

    private string gameId = "5347603";

#elif UNITY_IOS

    private string gameId = "5347602";

#endif


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Advertisement.Initialize(gameId, testMode, this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowAd(GameOverController gameOverController)
    {
        this.gameOverController = gameOverController;

        Advertisement.Show("Rewarded_Android", this);
    }

    public void ShowAdRewarded(ScoreController scoreController)
    {
        this.scoreController = scoreController;
        Advertisement.Show("Rewarded_Android", this);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete");
        Advertisement.Load("Rewarded_Android", this);
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Init Failed: {error} - {message}");
        Advertisement.Initialize(gameId, testMode, this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log($"Ad Loaded: {placementId}");
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error Loading Ad Unity {placementId}: {error} - {message}");
        Advertisement.Load("Rewarded_Android", this);
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Advertisement.Load("Rewarded_Android", this);
        Advertisement.Show("Rewarded_Android", this);
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowStart(string placementId)
    {
    }

    public void OnUnityAdsShowClick(string placementId)
    {
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        switch (showCompletionState)
        {
            case (UnityAdsShowCompletionState)UnityAdsCompletionState.COMPLETED:
                if (gameOverController != null)
                {
                    gameOverController.ContinueGame();
                }
                Debug.Log("AdCompleted");
                break;
            case (UnityAdsShowCompletionState)UnityAdsCompletionState.SKIPPED:
                gameOverController.ContinueGame();
                Debug.Log("AdSkipped");
                break;
            case (UnityAdsShowCompletionState)UnityAdsCompletionState.UNKNOWN:
                Debug.LogWarning("Ad Failed");
                break;
        }
    }
}
