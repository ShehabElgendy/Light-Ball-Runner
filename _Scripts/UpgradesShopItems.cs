using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesShopItems : MonoBehaviour
{
    [SerializeField]
    private UpgradesManager upgradesManager;

    [SerializeField]
    private int upgradeIndex;

    [SerializeField]
    private TextMeshProUGUI costText;

    [SerializeField]
    private Button buyButton;

    private Upgrades upgrades;

    private void Start()
    {
        upgrades = upgradesManager.upgrades[upgradeIndex];

        if (upgradesManager.IsUpgradeUnlocked(upgradeIndex))
        {
            buyButton.gameObject.SetActive(false);
        }
        else
        {
            buyButton.gameObject.SetActive(true);
            costText.text = upgrades.cost.ToString();
        }
    }

    public void OnBulletUpgradeBuyButtonPressed()
    {
        int diamonds = PlayerPrefs.GetInt("DiamondsCollected", 0);

        if (diamonds >= upgrades.cost && !upgradesManager.IsUpgradeUnlocked(upgradeIndex))
        {
            PlayerPrefs.SetInt("DiamondsCollected", diamonds - upgrades.cost);
            upgradesManager.UnlockUpgrade(upgradeIndex);
            buyButton.gameObject.SetActive(false);
            upgradesManager.SelectUpgrade(upgradeIndex);
            AudioManager.instance.PlaySFX(6);
        }
        else
        {
            AudioManager.instance.PlaySFX(7);
            Debug.Log("Not enough Diamonds");
        }
    }
}
