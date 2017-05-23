using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GloriousWhale.BeansJam17.Assets.Scripts.Constants;

public class DestroyOnLoose : MonoBehaviour {
    
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (SceneManager.GetActiveScene().name == SceneTypes.Lose_Screen)
        {
            Destroy(gameObject);
        }
	}
}
