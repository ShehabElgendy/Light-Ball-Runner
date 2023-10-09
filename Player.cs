using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private SkinsManager skinsManager;

    private TrailRenderer trailRenderer;

    private int skinIndex; 

    void Start()
    {
        skinIndex = PlayerPrefs.GetInt("SelectedSkin", 0);
        GetComponentInChildren<SpriteRenderer>().sprite = skinsManager.GetSelectedSkin().sprite;

        trailRenderer = GetComponentInChildren<TrailRenderer>();

        if (skinsManager.IsSkinUnlocked(0) && skinIndex == 0)
        {
            trailRenderer.startColor = Color.white;
            trailRenderer.endColor = Color.white;
        }
        if (skinsManager.IsSkinUnlocked(1) && skinIndex == 1)
        {
            trailRenderer.startColor = Color.black;
            trailRenderer.endColor = Color.black;
        }
        if (skinsManager.IsSkinUnlocked(2) && skinIndex == 2)
        {
            trailRenderer.startColor = new Color(0.5f, 0.15f, 0.3f);
            trailRenderer.endColor = new Color(0.5f, 0.15f, 0.3f);
        }
    }
}
