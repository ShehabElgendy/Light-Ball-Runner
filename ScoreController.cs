using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public static ScoreController instance;

    [SerializeField]
    private GameObject internetRechability;

    [SerializeField]
    private Button rewardedAdButton;

    private int diamondScore;

    private int counterHighScore;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        diamondScore = PlayerPrefs.GetInt("DiamondsCollected", diamondScore);
        counterHighScore = PlayerPrefs.GetInt("HighScore", counterHighScore);
    }

    public int GetScore()
    {
        diamondScore = PlayerPrefs.GetInt("DiamondsCollected", diamondScore);
        return diamondScore;
    }
    public int GetDiamondsCollected()
    {
        PlayerPrefs.SetInt("DiamondsCollected", diamondScore);
        return diamondScore;
    }

    public int GetHighScore()
    {
        if (counterHighScore < TimerController.instance.GetCounter())
        {
            counterHighScore = TimerController.instance.GetCounter();
            PlayerPrefs.SetInt("HighScore", counterHighScore);
        }
        return PlayerPrefs.GetInt("HighScore");
    }

    public void ModifyScore(int value)
    {
        diamondScore += value;
        Mathf.Clamp(diamondScore, 0, int.MaxValue);
    }

    public void ResetScore()
    {
        TimerController.instance.ResetCounter();
    }

    public void RewardedAdScoreButton()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            GameObject instance = Instantiate(internetRechability, transform.position, Quaternion.identity);
            Destroy(instance, 2);
        }
        if (AdmobAdsScript.instance.isRewardedAdLoaded == false) { return; }
        else
        {
            // Check if the button should be disabled
            if (PlayerPrefs.HasKey("lastClicked"))
            {
                float timeElapsed = (float)(DateTime.Now - DateTime.FromBinary(Convert.ToInt64(PlayerPrefs.GetString("lastClicked")))).TotalSeconds;
                if (timeElapsed < 60 * 60)
                {
                    // Disable the button
                    rewardedAdButton.enabled = false;
                    return;
                }
            }


            AdmobAdsScript.instance.ShowRewardedAdMainMenu();
            ModifyScore(200);
            GetDiamondsCollected();

            // Store the current time in PlayerPrefs
            PlayerPrefs.SetString("lastClicked", DateTime.Now.ToBinary().ToString());
        }
    }
}
