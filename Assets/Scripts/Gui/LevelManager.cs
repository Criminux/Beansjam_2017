using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    
    // Public variables
    public float secondsToAutoLoadNextLevel;

    // Private GameObjects
    private MusicManager musicManager;

    // Auto LoadLevel after X amount of seconds
    private void Start()
    {
        musicManager = FindObjectOfType<MusicManager>();
        if (secondsToAutoLoadNextLevel == 0)
            Debug.Log("Level auto load disabled");
        else
            Invoke("LevelManager_LoadNextLevel", secondsToAutoLoadNextLevel);
    }

    // Loading a specific scene
    public void LevelManager_LoadLevel(string name)
    {
        Debug.Log("Level load requested for: " + name);
        SceneManager.LoadScene(name);
    }

    // Quiting the application
    public void LevelManager_QuitRequest()
    {
        Debug.Log("Game is being closed...");
        Application.Quit();
        Debug.Log("Im closed now, do you not understand me!!!");
    }

    // Loading the next scene in the Scene Manager
    public void LevelManager_LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
