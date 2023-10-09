using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    [SerializeField]
    private Image selectedSkin;

    [SerializeField]
    private TextMeshProUGUI diamondsText;

    [SerializeField]
    private SkinsManager skinManager;

    [SerializeField]
    private GameObject shopPanel;

    private void Update()
    {
        diamondsText.text = PlayerPrefs.GetInt("DiamondsCollected").ToString();
        selectedSkin.sprite = skinManager.GetSelectedSkin().sprite;
    }

}
