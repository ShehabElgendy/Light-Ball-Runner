using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUIDisplay : MonoBehaviour
{
    [SerializeField]
    private Slider healthSlider;

    [SerializeField]
    private TextMeshProUGUI counterScoreText;

    [SerializeField]
    private TextMeshProUGUI diamondCollectedText;

    [SerializeField]
    private TextMeshProUGUI HighScoreText;

    [SerializeField]
    private GameObject pauseScreen;

    private TouchController TouchController;

    private void Awake()
    {
        TouchController = FindObjectOfType<TouchController>();
    }

    private void Start()
    {
        ScoreController.instance.GetScore();
        healthSlider.maxValue = HealthController.instance.GetMaxHealth();
        healthSlider.value = HealthController.instance.GetCurrentHealth();
        counterScoreText.text = TimerController.instance.GetCounter().ToString();
        HighScoreText.text = ScoreController.instance.GetHighScore().ToString();
        diamondCollectedText.text = ScoreController.instance.GetDiamondsCollected().ToString();
    }

    void Update()
    {
        healthSlider.maxValue = HealthController.instance.GetMaxHealth();
        healthSlider.value = HealthController.instance.GetCurrentHealth();
        if (!HealthController.instance.isAlive) { return; }
        counterScoreText.text = TimerController.instance.GetCounter().ToString();
        HighScoreText.text = ScoreController.instance.GetHighScore().ToString();
        diamondCollectedText.text = ScoreController.instance.GetDiamondsCollected().ToString();
    }

    public void PauseButton()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        pauseScreen.gameObject.SetActive(true);
    }

    public void ResumeButton()
    {
        pauseScreen.gameObject.SetActive(false);
        Time.timeScale = 1;
        AudioListener.pause = false;
        TouchController.canMove = true;
    }

    public void OnPointerDownPauseButton()
    {
        TouchController.canMove = false;
    }

    public void UpdateHealth(int currentHealth, int maxHealth)
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }
}
