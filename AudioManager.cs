using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField]
    private AudioSource mainMenuMusic, levelMusic1, levelMusic2;

    [SerializeField]
    private AudioSource[] sfx;

    [SerializeField]
    private UnityEngine.UI.Toggle audioToggle;



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

    public void PlayMainMenuMusic()
    {
        levelMusic1.Stop();
        levelMusic2.Stop();
        mainMenuMusic.Play();
    }

    public void PlayLevelMusic()
    {
        mainMenuMusic.Stop();
        double introDuration = (double)levelMusic1.clip.samples / levelMusic1.clip.frequency;
        double startTime = AudioSettings.dspTime + 0.2;
        levelMusic1.PlayScheduled(startTime);
        levelMusic2.PlayScheduled(startTime + introDuration - 20f);
    }

    public void PlaySFX(int sfxToPlay)
    {
        sfx[sfxToPlay].Stop();
        sfx[sfxToPlay].Play();
    }

    public void PlaySFXAdjusted(int sfxToAdjust)
    {
        sfx[sfxToAdjust].pitch = Random.Range(1f, 1.4f);
        PlaySFX(sfxToAdjust);
    }

    IEnumerator PlayLevelMusic2()
    {
        yield return new WaitForSeconds(75f);
        levelMusic1.Stop();
        levelMusic2.PlayScheduled(AudioSettings.dspTime + 2f);
    }

    public void MuteToggel(bool muted)
    {
        ColorBlock cb = audioToggle.colors;

        if (muted)
        {
            AudioListener.volume = 0;
            cb.selectedColor = Color.gray;
        }
        else
        {
            AudioListener.volume = 1;
            cb.selectedColor = Color.white;
        }
        audioToggle.colors = cb;
    }
}
