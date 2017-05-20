﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.Player
{
	public class PlayerShooting : MonoBehaviour
	{

		WeaponScript[] weapons;

		// Use this for initialization
		void Start()
		{
			weapons = FindObjectsOfType<WeaponScript>();
		}

		// Update is called once per frame
		void Update()
		{
			if (Input.GetMouseButton(0))
			{
				foreach (WeaponScript weapon in weapons)
				{
					weapon.Shoot();
				}
			}
		}
	}
}