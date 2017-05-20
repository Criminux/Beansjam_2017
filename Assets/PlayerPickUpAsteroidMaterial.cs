using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Constants;
using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.GameObjects;
using UnityEngine;
using GloriousWhale.BeansJam17.Assets.Scripts.Constants;

namespace GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.Ship
{

	public class PlayerPickUpAsteroidMaterial : MonoBehaviour
	{
		[SerializeField] private int itemsPerPickup;

		private CargoHold cargoHold;

		void Start()
		{
			cargoHold = GetComponent<CargoHold>();
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.tag == Tags.AsteroidPickUp)
			{
				cargoHold.AddItem(ItemType.Asteroid_Material, itemsPerPickup);
				Destroy(other.gameObject);
			}
		}
	}
}
