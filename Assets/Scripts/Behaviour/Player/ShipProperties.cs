using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.Player
{
	public class ShipProperties : MonoBehaviour
	{

		[SerializeField] private int initialFuel = 10;
		[SerializeField] private int initialAmmo = 25;

		public int Fuel { get; set; }

		public int Ammo { get; set; }

		void Start()
		{
			Fuel = initialFuel;
			Ammo = initialAmmo;
		}
	}
}
