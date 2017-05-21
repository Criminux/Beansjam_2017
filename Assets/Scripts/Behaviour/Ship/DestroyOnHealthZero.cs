using System.Collections;
using System.Collections.Generic;
using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.GameObjects;
using UnityEngine;
using GloriousWhale.BeansJam17.Assets.Scripts.Constants;
using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.Ship;

public class DestroyOnHealthZero : MonoBehaviour {
	
	void Start () {
        GetComponent<ObjectHealth>().HealthReachedZero += () => 
        {
            GameObject.FindGameObjectWithTag(Tags.Player).GetComponent<PlayerProperties>().Money += 25;
            Destroy(gameObject);
        };
    }

}
