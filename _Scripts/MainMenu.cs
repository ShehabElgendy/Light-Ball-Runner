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

    [SerializeField]
    private GameObject shopLight;


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
        SceneManager.LoadScene(1);
        AudioManager.instance.PlaySFX(6);
    }

    public void ShowShopPanel()
    {
        shopPanel.SetActive(true);
        shopLight.SetActive(true);
        AudioManager.instance.PlaySFX(6);
    }

    public void CloseShopPanel()
    {
        shopPanel.SetActive(false);
        shopLight.SetActive(false);
        AudioManager.instance.PlaySFX(6);
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
