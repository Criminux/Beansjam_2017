using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.GameObjects;
using GloriousWhale.BeansJam17.Assets.Scripts.Constants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.Player
{
	public class ShipProperties : MonoBehaviour
	{

		[SerializeField] private int initialFuel = 10;
		[SerializeField] private int initialAmmo = 25;

        private CargoHold cargo;

		public int Fuel
        {
            get
            {
                return cargo.GetAmountOf(ItemType.Fuel);
            }

            set
            {
                cargo.AddItem(ItemType.Fuel, value);
            }
        }

		public int Ammo { get; set; }

		void Start()
		{
			Fuel = initialFuel;
			Ammo = initialAmmo;

            cargo = GetComponent<CargoHold>();
		}
	}
}
