using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Behaviour.Player;
using UnityEngine;

namespace GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.Player
{

	public class ProjectileHitting : MonoBehaviour
	{
		private Projectile projectile;

		void Start()
		{
			projectile = GetComponent<Projectile>();
		}

		void OnCollisionEnter(Collision collision)
		{
			Debug.Log("Blubb");

			var hitListener = collision.gameObject.GetComponent<ProjectileHitListener>();
			if(hitListener != null)
				hitListener.Hit(projectile.Impact);
		}
	}
}