using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level_unlocked_";
    const string X_INVERTED = "x_inverted";
    const string Y_INVERTED = "y_inverted";

    // Inverted Controls
    public static void SetInvertedX(bool inverted)
    {
        if(inverted) PlayerPrefs.SetInt(X_INVERTED, 1);
        else PlayerPrefs.SetInt(X_INVERTED, 0);
    }

    public static bool GetInvertedX()
    {
        if(PlayerPrefs.GetInt(X_INVERTED) == 1) return true;
        else return false;
    }
    public static void SetInvertedY(bool inverted)
    {
        if (inverted) PlayerPrefs.SetInt(Y_INVERTED, 1);
        else PlayerPrefs.SetInt(Y_INVERTED, 0);
    }

    public static bool GetInvertedY()
    {
        if (PlayerPrefs.GetInt(Y_INVERTED) == 1) return true;
        else return false;
    }

    // Master Volume
    public static void SetMasterVolume(float volume)
    {
        if (volume > 0f && volume < 1f)
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        else
            Debug.LogError("Master volume out of range");
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    // Difficulty
    public static void SetDifficulty(float difficulty)
    {
        if (difficulty >= 1f && difficulty <= 3)
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        else
            Debug.LogError("Difficulty out of range");
    }

    public static float GetDifficulty()
    {
            return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }

    // Level ID
    public static void UnlockLevel(int level)
    {
        if (level <= SceneManager.sceneCountInBuildSettings - 1)
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1); // Use 1 for true
        else
            Debug.LogError("(SET) Level ID out of Range");
    }

    public static bool IsLevelUnlocked(int level)
    {
        int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString());
        bool isLevelUnlocked = (levelValue == 1);

        if (level <= SceneManager.sceneCountInBuildSettings - 1)
            return isLevelUnlocked;
        else
        {
            Debug.LogError("(GET) Level ID out of Range");
            return false;
        }
    }

}
