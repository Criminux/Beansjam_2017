using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GloriousWhale.BeansJam17.Assets.Scripts.Constants;

namespace GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.Ship
{

	public class PlayerPickUpAsteroidMaterial : MonoBehaviour
	{

		private void OnTriggerEnter(Collider other)
		{
			if (other.tag == Tags.AsteroidPickUp)
			{
				//TODO: Add Material to Player-Cargo
				Debug.Log("Aufgehoben: Material");

				Destroy(other.gameObject);
			}
		}
	}
}
