using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{

    [SerializeField]
    private GameObject gameOverDisplay;

    [SerializeField]
    private GameObject gamePanelDisplay;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    [SerializeField]
    private TextMeshProUGUI highScoreText;

    [SerializeField]
    private Button continueButton;

    [SerializeField]
    private Button pauseButton;   

    [SerializeField]
    private GameObject damageAllButton;

    [SerializeField]
    private int continueTrials = 3;

    [SerializeField]
    private GameObject internetRechability;

    [SerializeField]
    private RectTransform spawnerTxtPos;

    [SerializeField]
    private Image countDownTimerImg;

    [SerializeField]
    private TextMeshProUGUI watchAdText;

    private ScoreController scoreController;


    private void Awake()
    {
        scoreController = FindObjectOfType<ScoreController>();
    }

    private void Start()
    {
        AdmobAdsScript.instance.LoadRewardedAd();
        countDownTimerImg.fillAmount = 1f;
    }

    private void Update()
    {
        if(!HealthController.instance.isAlive)
        {
            WatchADToContinue();
        }
    }

    public void EndGame()
    {
        gameOverDisplay.SetActive(true);
        pauseButton.interactable = false;
        damageAllButton.SetActive(false);
        scoreText.text = "Score\n" + TimerController.instance.GetCounter().ToString(); ;
        highScoreText.text = "Best\n" + scoreController.GetHighScore();
        gamePanelDisplay.SetActive(false);
        AdmobAdsScript.instance.ShowInterADAfterCounter();
    }
    public void PlayAgain()
    {
        scoreController.ResetScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        AudioManager.instance.PlaySFX(6);
    }

    public void ContinueGameButton()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable || AdmobAdsScript.instance.isRewardedAdLoaded == false)
        {
            GameObject instance = Instantiate(internetRechability, spawnerTxtPos.anchoredPosition, Quaternion.identity);
            Destroy(instance, 2);
        }
        else
        {
            continueTrials--;
            countDownTimerImg.fillAmount = 1f;

            if (continueTrials <= 0)
            {
                continueButton.interactable = false;
                countDownTimerImg.gameObject.SetActive(false);
                watchAdText.gameObject.SetActive(false);
            }
            AdmobAdsScript.instance.ShowRewardedAd();
            gamePanelDisplay.SetActive(true);
            gameOverDisplay.SetActive(false);
            AudioManager.instance.PlaySFX(6);
        }
    }

    public void ReturnToMenu()
    {
        scoreController.ResetScore();
        SceneManager.LoadScene(0);
        AudioManager.instance.PlaySFX(6);
        AudioManager.instance.PlayMainMenuMusic();
    }

    public void ContinueGame()
    {
        HealthController.instance.isAlive = true;
        gameOverDisplay.SetActive(false);
        pauseButton.interactable = true;
        damageAllButton.SetActive(true);
        HealthController.instance.Revive();
        AudioManager.instance.PlaySFX(6);
        AdmobAdsScript.instance.LoadRewardedAd();
    }

    public void WatchADToContinue()
    {
        float coolDownTime = 5f;
        countDownTimerImg.fillAmount -= 1 / coolDownTime * Time.deltaTime;

        if (countDownTimerImg.fillAmount <= 0f)
        {
            continueButton.interactable = false;
            countDownTimerImg.gameObject.SetActive(false);
            watchAdText.gameObject.SetActive(false);
        }
    }

}
