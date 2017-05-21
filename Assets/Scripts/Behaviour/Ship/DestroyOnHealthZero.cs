using System.Collections;
using System.Collections.Generic;
using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.GameObjects;
using UnityEngine;

public class DestroyOnHealthZero : MonoBehaviour {
	
	void Start () {
		GetComponent<ObjectHealth>().HealthReachedZero += () => Destroy(gameObject);
	}
	
}
