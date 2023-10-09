using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkinManager", menuName = "SkinManager")]
public class SkinsManager : ScriptableObject
{
    [SerializeField]
    public Skins[] skins;

    private const string Prefix = "_Skin";

    private const string SelectedSkin = "SelectedSkin";

    public void SelectSkin(int  skinIndex) => PlayerPrefs.SetInt(SelectedSkin, skinIndex);

    public Skins GetSelectedSkin()
    {
        int skinIndex = PlayerPrefs.GetInt(SelectedSkin, 0);
        if (skinIndex >= 0 && skinIndex < skins.Length)
        {
            return skins[skinIndex];
        }
        else
        {
            return null;
        }
    }


    public void UnlockSkin(int skinIndex) => PlayerPrefs.SetInt(Prefix + skinIndex, 1);

    public bool IsSkinUnlocked(int skinIndex) => PlayerPrefs.GetInt(Prefix + skinIndex, 0) == 1;

}
