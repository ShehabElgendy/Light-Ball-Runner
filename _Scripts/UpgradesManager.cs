using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradesManager", menuName = "UpgradesManager")]
public class UpgradesManager : ScriptableObject
{
    [SerializeField]
    public Upgrades[] upgrades;

    private const string Prefix = "_Upgrade";

    private const string SelektedUpgrade = "SelectedUpgrade";

    public void SelectUpgrade(int upgradeIndex) => PlayerPrefs.SetInt(SelektedUpgrade, upgradeIndex);

    public Upgrades GetSelectedUpgrade()
    {
        int upgradeIndex = PlayerPrefs.GetInt(SelektedUpgrade, 0);
        if (upgradeIndex >= 0 && upgradeIndex < upgrades.Length)
        {
            return upgrades[upgradeIndex];
        }
        else
        {
            return null;
        }
    }

    public void UnlockUpgrade(int upgradeIndex) => PlayerPrefs.SetInt(Prefix + upgradeIndex, 1);

    public bool IsUpgradeUnlocked(int upgradeIndex) => PlayerPrefs.GetInt(Prefix + upgradeIndex, 0) == 1;
}