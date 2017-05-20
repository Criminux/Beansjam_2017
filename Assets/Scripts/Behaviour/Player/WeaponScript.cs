using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.Player
{
	public class WeaponScript : MonoBehaviour
	{

		[SerializeField] GameObject projectile;
		[SerializeField] Transform projectileSpawn;
		GameObject Player;

		private void Start()
		{
			Player = GameObject.FindGameObjectWithTag("Player");
		}

		public void Shoot()
		{
			Instantiate(projectile, projectileSpawn.position, Player.transform.rotation);
		}

	}
}