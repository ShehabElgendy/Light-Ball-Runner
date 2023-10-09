using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinsShopItems : MonoBehaviour
{
    [SerializeField]
    private SkinsManager skinsManager;

    [SerializeField]
    private int skinIndex;

    [SerializeField]
    private Button buyButton;

    [SerializeField]
    private TextMeshProUGUI costText;

    private Skins skin;

    private void Start()
    {
        skinsManager.UnlockSkin(0);
        skin = skinsManager.skins[skinIndex];

        GetComponent<Image>().sprite = skin.sprite;

        if (skinsManager.IsSkinUnlocked(skinIndex))
        {
            buyButton.gameObject.SetActive(false);
        }
        else
        {
            buyButton.gameObject.SetActive(true);
            costText.text = skin.cost.ToString();
        }
    }

    public void OnSkinPressed()
    {
        if (skinsManager.IsSkinUnlocked(skinIndex))
        {
            skinsManager.SelectSkin(skinIndex);
            AudioManager.instance.PlaySFX(6);
        }
    }

    public void OnSkinBuyButtonPressed()
    {
        int diamonds = PlayerPrefs.GetInt("DiamondsCollected", 0);

        if (diamonds >= skin.cost && !skinsManager.IsSkinUnlocked(skinIndex))
        {
            PlayerPrefs.SetInt("DiamondsCollected", diamonds - skin.cost);
            skinsManager.UnlockSkin(skinIndex);
            buyButton.gameObject.SetActive(false);
            skinsManager.SelectSkin(skinIndex);
            AudioManager.instance.PlaySFX(6);
        }
        else
        {
            AudioManager.instance.PlaySFX(7);
            Debug.Log("Not enough Diamonds");
        }
    }
}
