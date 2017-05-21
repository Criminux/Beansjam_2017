using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.Ship;
using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.Player;
using GloriousWhale.BeansJam17.Assets.Scripts.Constants;

public class HUD_Texts : MonoBehaviour {

    Text text;
    PlayerProperties playerProperties;
    ShipProperties shipProperties;

    [SerializeField] bool isMoney;
    [SerializeField] bool isCrew;
    [SerializeField] bool isFuel;
    [SerializeField] bool isAmmo;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
        playerProperties = GameObject.FindGameObjectWithTag(Tags.Player).GetComponent<PlayerProperties>();
        shipProperties = GameObject.FindGameObjectWithTag(Tags.Player).GetComponent<ShipProperties>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoney) text.text = playerProperties.Money.ToString();
        if (isCrew) text.text = playerProperties.Crew.ToString();
        if (isFuel) text.text = shipProperties.Fuel.ToString();
        if (isAmmo) text.text = shipProperties.Ammo.ToString();
    }
}
