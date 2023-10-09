using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    //[SerializeField]
    //private GameObject shopPanel;

    //[SerializeField]
    //private Slider volumeSlider; 

    [SerializeField]
    private GameObject shopPanel;

    private int levelIndex;

    private void Start()
    {
        AudioManager.instance.PlayMainMenuMusic();
        //if (!PlayerPrefs.HasKey("musicVolume"))
        //{
        //    PlayerPrefs.SetFloat("musicVolume", 1);
        //    Load();
        //}
        //else
        //{
        //    Load();
        //}
    }
    public void StartGame()
    {
        levelIndex = PlayerPrefs.GetInt("SelectedLevel", 0);
        SceneManager.LoadScene(levelIndex + 1);
        AudioManager.instance.PlaySFX(6);
    }

    public void ShowShopPanel()
    {
        AudioManager.instance.PlaySFX(6);
        shopPanel.SetActive(true);
    }

    public void CloseShopPanel()
    {
        AudioManager.instance.PlaySFX(6);
        shopPanel.SetActive(false);
    }

    //public void ShowShopPanel()
    //{
    //    shopPanel.SetActive(true);
    //}

    //public void ChangeVolume()
    //{
    //    AudioListener.volume = volumeSlider.value;
    //    Save();
    //}

    //private void Load()
    //{
    //    volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    //}

    //private void Save()
    //{
    //    PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    //}

    //public void OnVolumeButtonPress()
    //{
    //    volumeSlider.gameObject.SetActive(true);
    //}

    //public void OnVolumeSliderDeselect()
    //{
    //    volumeSlider.gameObject.SetActive(false);
    //}
}
