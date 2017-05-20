using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {
    // Public 
    public Slider volumeSlider, difficultySlider, levelSlider;

    // Private
    private LevelManager levelManager;
    private MusicManager musicManager;

	// Use this for initialization
	void Start () {
        levelManager = FindObjectOfType<LevelManager>();
        musicManager = FindObjectOfType<MusicManager>();

        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        difficultySlider.value = PlayerPrefsManager.GetDifficulty();
	}
	
	// Update is called once per frame
	void Update () {
        musicManager.SetVolume(volumeSlider.value);
	}

    public void SaveAndExit()
    {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        PlayerPrefsManager.SetDifficulty(difficultySlider.value);
        levelManager.LevelManager_LoadLevel("Main Menu");
    }

    public void SetDefaults()
    {
        volumeSlider.value = 0.1f;
        difficultySlider.value = 2f;
    }

}
