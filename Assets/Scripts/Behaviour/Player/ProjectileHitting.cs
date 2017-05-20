using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Behaviour.Player;
using UnityEngine;

namespace GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.Player
{

	public class ProjectileHitting : MonoBehaviour
	{
		private Projectile projectile;

		[SerializeField] private GameObject particle;
		[SerializeField] private float particleDuration =.2f;

		void Start()
		{
			projectile = GetComponent<Projectile>();
		}

		void OnCollisionEnter(Collision collision)
		{
			var hitListener = collision.gameObject.GetComponent<ProjectileHitListener>();
			if(hitListener != null)
				hitListener.Hit(projectile.Impact);

			var particleInstance = Instantiate(particle, transform.position, transform.rotation);
			Destroy(particleInstance, particleDuration);
			Destroy(gameObject);
		}
	}
}