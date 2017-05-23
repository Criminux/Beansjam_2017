using System.Collections;
using System.Collections.Generic;
using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.GameObjects;
using UnityEngine;
using GloriousWhale.BeansJam17.Assets.Scripts.Constants;
using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.Ship;

public class DestroyOnHealthZero : MonoBehaviour {
	
    [SerializeField]
    int objectKillReward;

	void Start () {
        GetComponent<ObjectHealth>().HealthReachedZero += () => 
        {
            GameObject.FindGameObjectWithTag(Tags.Player).GetComponent<PlayerProperties>().Money += objectKillReward;
            Destroy(gameObject);
        };
    }

}
