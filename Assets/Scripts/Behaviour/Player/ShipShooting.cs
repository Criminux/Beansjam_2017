using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.Player
{
	public class ShipShooting : MonoBehaviour
	{

		private WeaponController[] weapons;
		private InputProvider inputProvider;

		void Start()
		{
			weapons = FindObjectsOfType<WeaponController>();
			inputProvider = GetComponent<InputProvider>();
		}
		
		void Update()
		{
			if (inputProvider.GetShootingInput())
				foreach (WeaponController weapon in weapons)
					weapon.Shoot();
		}

		public interface InputProvider
		{
			bool GetShootingInput();
		}
	}
}