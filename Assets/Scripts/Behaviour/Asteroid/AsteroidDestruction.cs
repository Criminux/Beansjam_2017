using System.Collections;
using System.Collections.Generic;
using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.GameObjects;
using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.Player;
using UnityEngine;

public class AsteroidDestruction : MonoBehaviour {
	
	void Start ()
	{
		GetComponent<ObjectHealth>().HealthReachedZero += () => 
		Destroy(gameObject);
	}
	
}
