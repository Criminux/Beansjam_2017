using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {
    
    // Public GameObjects
    public AudioClip[] sceneMusicChangeArray;

    // Private GameObjects
    private AudioSource audioSource;
    private LevelManager levelManager;

	// To keep the MusicManager all game
	void Awake () {
        DontDestroyOnLoad(gameObject);
	}

    // To automatically assign the GameObjects
    private void Start()
    {
        levelManager = GetComponent<LevelManager>();
        audioSource = GetComponent<AudioSource>();
    }

    // To check for a new scene, and load there assignt music
    private void OnLevelWasLoaded(int level)
    {
        AudioClip thisLevelMusic = sceneMusicChangeArray[level];
        print("Choosen Music: " + level + " - " + thisLevelMusic);

        if (thisLevelMusic)
        {
            audioSource.clip = thisLevelMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }


}