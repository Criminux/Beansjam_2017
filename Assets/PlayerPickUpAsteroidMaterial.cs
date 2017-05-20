using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GloriousWhale.BeansJam17.Assets.Scripts.Constants;

public class PlayerPickUpAsteroidMaterial : MonoBehaviour {
    
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == Tags.AsteroidPickUp)
        {
            //TODO: Add Material to Player-Cargo
            Debug.Log("Aufgehoben: Material");
        }
    }
}
