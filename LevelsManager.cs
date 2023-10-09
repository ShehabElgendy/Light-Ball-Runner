using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelsManager", menuName = "LevelsManager")]
public class LevelsManager : ScriptableObject
{
    [SerializeField]
    public Levels[] levels;

    private const string Prefix = "_Level";

    private const string SelectedLevel = "SelectedLevel";

    public void SelectLevel(int levelIndex) => PlayerPrefs.SetInt(SelectedLevel, levelIndex);

    public Levels GetSelectedLevel()
    {
        int levelIndex = PlayerPrefs.GetInt(SelectedLevel, 0);
        if (levelIndex >= 0 && levelIndex < levels.Length)
        {
            return levels[levelIndex];
        }
        else
        {
            return null;
        }
    }

    public void UnlockLevel(int levelIndex) => PlayerPrefs.SetInt(Prefix + levelIndex, 1);

    public bool IsLevelUnlocked(int levelIndex) => PlayerPrefs.GetInt(Prefix + levelIndex, 0) == 1;
}