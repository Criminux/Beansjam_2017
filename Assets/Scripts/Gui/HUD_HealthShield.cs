using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.GameObjects;
using GloriousWhale.BeansJam17.Assets.Scripts.Constants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_HealthShield : MonoBehaviour {

    Text text;
    ObjectHealth playerHealth;

    [SerializeField]
    bool isHealth;
    [SerializeField]
    bool isShield;

    void Start ()
    {
        text = GetComponent<Text>();
        playerHealth = GameObject.FindGameObjectWithTag(Tags.Player).GetComponent<ObjectHealth>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (isHealth) text.text = playerHealth.Health.ToString();
        if (isShield) text.text = playerHealth.Shield.ToString();
    }
}
