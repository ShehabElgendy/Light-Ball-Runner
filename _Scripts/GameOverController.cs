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

    private ScoreController scoreController;

    private void Awake()
    {
        scoreController = FindObjectOfType<ScoreController>();
    }

    public void EndGame()
    {
        gameOverDisplay.SetActive(true);
        pauseButton.interactable = false;
        damageAllButton.SetActive(false);
        scoreText.text = "Score\n" + TimerController.instance.GetCounter().ToString(); ;
        highScoreText.text = "Best\n" + scoreController.GetHighScore();
        gamePanelDisplay.SetActive(false);
    }
    public void PlayAgain()
    {
        scoreController.ResetScore();
        SceneManager.LoadScene(1);
        AudioManager.instance.PlaySFX(6);
    }

    public void ContinueGameButton()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            GameObject instance = Instantiate(internetRechability, transform.position, Quaternion.identity);
            Destroy(instance, 2);
        }
        else
        {
            continueTrials--;

            if (continueTrials <= 0)
            {
                continueButton.interactable = false;
            }

            AdManager.instance.ShowAd(this);
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
    }
}
