using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelsShopItem : MonoBehaviour
{
    [SerializeField]
    private LevelsManager levelsManager;

    [SerializeField]
    private int levelIndex;

    [SerializeField]
    private TextMeshProUGUI costText;

    [SerializeField]
    private Button buyButton;

    [SerializeField]
    private GameObject[] levelsBg;

    [SerializeField]
    private Button[] levelButtons;

    private Levels levels;

    private CarMoveForward movingScene;



    private void Awake()
    {
        movingScene = FindObjectOfType<CarMoveForward>();
    }
    private void Start()
    {
        levelsManager.UnlockLevel(0);
        levels = levelsManager.levels[levelIndex];

        if (levelsManager.IsLevelUnlocked(levelIndex))
        {
            buyButton.gameObject.SetActive(false);
        }
        else
        {
            buyButton.gameObject.SetActive(true);
            costText.text = levels.cost.ToString();
        }
    }

    public void OnLevelPressed()
    {
        ActivateLevelButtons();
        if (levelsManager.IsLevelUnlocked(levelIndex))
        {
            Animations.instance.StopFadeAnimation();
            AudioManager.instance.PlaySFX(6);
            if (levelsBg[levelIndex].activeSelf) { return; }
            Animations.instance.PlayFadeAnimation();
            levelsManager.SelectLevel(levelIndex);
            for (int i = 0; i < levelsBg.Length; i++)
            {

                foreach (Button button in levelButtons)
                {
                    button.interactable = false;
                }
                if (!levelsBg[i].Equals(levelIndex))
                {
                    movingScene.transform.position = new Vector2(movingScene.transform.position.x + 75f, movingScene.transform.position.y);
                    levelsBg[levelIndex].SetActive(true);
                }
                else
                {
                    levelsBg[5].SetActive(true) ;
                }
                levelsBg[i].SetActive(false);
            }
        }
    }

    public void ActivateLevelButtons()
    {
        foreach (Button button in levelButtons)
        {
            button.interactable = true;
        }
    }

    public void OnLevelButtonPressed()
    {
        int diamonds = PlayerPrefs.GetInt("DiamondsCollected", 0);

        if (diamonds >= levels.cost && !levelsManager.IsLevelUnlocked(levelIndex))
        {
            PlayerPrefs.SetInt("DiamondsCollected", diamonds - levels.cost);
            levelsManager.UnlockLevel(levelIndex);
            buyButton.gameObject.SetActive(false);
            levelsManager.SelectLevel(levelIndex);
            AudioManager.instance.PlaySFX(6);
        }
        else
        {
            AudioManager.instance.PlaySFX(7);
            Debug.Log("Not enough Diamonds");
        }
    }
}
