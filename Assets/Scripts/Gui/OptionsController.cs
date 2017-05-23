using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {
    // Public 
    public Slider volumeSlider;

    // Private
    private LevelManager levelManager;
    private MusicManager musicManager;

    [SerializeField]
    Toggle invertXToggle, invertYToggle;

	// Use this for initialization
	void Start () {
        levelManager = FindObjectOfType<LevelManager>();
        musicManager = FindObjectOfType<MusicManager>();

        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
	}
	
	// Update is called once per frame
	void Update () {
        musicManager.SetVolume(volumeSlider.value);
	}

    public void SaveAndExit()
    {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);

        PlayerPrefsManager.SetInvertedX(invertXToggle.isOn);
        PlayerPrefsManager.SetInvertedY(invertYToggle.isOn);

        levelManager.LevelManager_LoadLevel("Main Menu");
    }

    public void SetDefaults()
    {
        volumeSlider.value = 0.1f;

        invertXToggle.isOn = false;
        invertYToggle.isOn = false;
    }
    
}
