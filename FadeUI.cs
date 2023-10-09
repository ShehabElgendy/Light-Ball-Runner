using DG.Tweening;
using System.Collections;
using UnityEngine;

public class FadeUI : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup fadingCanvasGroup;

    private MainMenu mainMenu;

    private bool isFaded = true;

    private void Awake()
    {
        mainMenu = FindObjectOfType<MainMenu>();
    }

    public void Fader()
    {
        isFaded = !isFaded;

        if (isFaded)
        {
            fadingCanvasGroup.DOFade(1, 0.5f);
            mainMenu.ShowShopPanel();
        }
        else
        {
            fadingCanvasGroup.DOFade(0, 0.5f);
            mainMenu.CloseShopPanel();
        }
    }

    public void FadeLevelBG()
    {

        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        fadingCanvasGroup.DOFade(1, 0f);
        yield return new WaitForSeconds(1f);
        fadingCanvasGroup.DOFade(0, 0.5f);
    }
}
