using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.Ship;
using GloriousWhale.BeansJam17.Assets.Scripts.Constants;

public class HUD_Credits : MonoBehaviour {

    Text text;
    PlayerProperties playerProperties;

    // Use this for initialization
    void Start ()
    {
        text = GetComponent<Text>();
        playerProperties = GameObject.FindGameObjectWithTag(Tags.Player).GetComponent<PlayerProperties>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        text.text = playerProperties.Money.ToString();
	}
}
