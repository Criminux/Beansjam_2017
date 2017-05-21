using GloriousWhale.BeansJam17.Assets.Scripts.Constants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ExtensionModelManager : MonoBehaviour {

    [SerializeField]
    GameObject WeaponStufe1, WeaponStufe2, WeaponStufe3;
    [SerializeField]
    GameObject ThrusterStufe1, ThrusterStufe2, ThrusterStufe3;
    [SerializeField]
    GameObject ShieldStufe1, ShieldStufe2, ShieldStufe3, ShieldStufe4;

	// Use this for initialization
	void Start ()
    {
        GetComponent<ExtensionManager>().Equipped += (type) => OnEquip(type);
	}

    private void OnEquip(ItemType type)
    {
        if(type == ItemType.ShieldTier1)
        {
            ShieldStufe1.SetActive(true);
            ShieldStufe2.SetActive(false);
            ShieldStufe3.SetActive(false);
            ShieldStufe4.SetActive(false);
        }
        else if(type == ItemType.ShieldTier2)
        {
            ShieldStufe1.SetActive(true);
            ShieldStufe2.SetActive(true);
            ShieldStufe3.SetActive(false);
            ShieldStufe4.SetActive(false);
        }
        else if (type == ItemType.ShieldTier3)
        {
            ShieldStufe1.SetActive(true);
            ShieldStufe2.SetActive(true);
            ShieldStufe3.SetActive(true);
            ShieldStufe4.SetActive(false);
        }
        else if (type == ItemType.ShieldTier4)
        {
            ShieldStufe1.SetActive(true);
            ShieldStufe2.SetActive(true);
            ShieldStufe3.SetActive(true);
            ShieldStufe4.SetActive(true);
        }
        else if (type == ItemType.ThrustTier1)
        {
            ThrusterStufe1.SetActive(true);
            ThrusterStufe2.SetActive(false);
            ThrusterStufe3.SetActive(false);
        }
        else if (type == ItemType.ThrustTier2)
        {
            ThrusterStufe1.SetActive(true);
            ThrusterStufe2.SetActive(true);
            ThrusterStufe3.SetActive(false);
        }
        else if (type == ItemType.ThrustTier3)
        {
            ThrusterStufe1.SetActive(true);
            ThrusterStufe2.SetActive(true);
            ThrusterStufe3.SetActive(true);
        }
        else if (type == ItemType.WeaponTier1)
        {
            WeaponStufe1.SetActive(true);
            WeaponStufe2.SetActive(false);
            WeaponStufe3.SetActive(false);
        }
        else if(type == ItemType.WeaponTier2)
        {
            WeaponStufe1.SetActive(true);
            WeaponStufe2.SetActive(true);
            WeaponStufe3.SetActive(false);
        }
        else if(type == ItemType.WeaponTier3)
        {
            WeaponStufe1.SetActive(true);
            WeaponStufe2.SetActive(true);
            WeaponStufe3.SetActive(true);
        }
    }
}
