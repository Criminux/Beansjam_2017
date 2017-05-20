using System.Collections;
using System.Collections.Generic;
using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.GameObjects;
using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.Player;
using UnityEngine;

public class AsteroidDestruction : MonoBehaviour {

    [SerializeField]
    GameObject pickUp;

	void Start ()
	{
        Instantiate(pickUp, transform.position, Quaternion.identity);
        GetComponent<ObjectHealth>().HealthReachedZero += () => 
		Destroy(gameObject);
	}
	
}
