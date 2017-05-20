using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.Player
{
	public class ShipShooting : MonoBehaviour
	{
		[SerializeField]
		private GameObject[] weapons;

		private List<WeaponController> weaponControllers;
		
		private InputProvider inputProvider;

		void Start()
		{
			weaponControllers = weapons
				.Select(weaponObject => weaponObject.GetComponent<WeaponController>())
				.ToList();
			inputProvider = GetComponent<InputProvider>();
		}
		
		void Update()
		{
			if (inputProvider.GetShootingInput())
				foreach (var weapon in weaponControllers)
					weapon.Shoot();
		}

		public interface InputProvider
		{
			bool GetShootingInput();
		}
	}
}