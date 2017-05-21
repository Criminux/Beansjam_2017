using System.Collections;
using System.Collections.Generic;
using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.GameObjects;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseOnHealthZero : MonoBehaviour {

	void Start()
	{
		GetComponent<ObjectHealth>().HealthReachedZero += () => SceneManager.LoadScene("Lose Screen");
	}
	
}
