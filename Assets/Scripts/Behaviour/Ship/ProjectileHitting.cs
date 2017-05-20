using System.Collections;
using System.Collections.Generic;
using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.GameObjects;
using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.Player;
using UnityEngine;

namespace GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.Ship
{

	public class ProjectileHitting : MonoBehaviour
	{
		private ProjectileController _projectileController;

		[SerializeField] private GameObject particle;
		[SerializeField] private float particleDuration =.2f;

		void Start()
		{
			_projectileController = GetComponent<ProjectileController>();
		}

		void OnCollisionEnter(Collision collision)
		{
			var hitListener = collision.gameObject.GetComponent<ProjectileHitListener>();
			if(hitListener != null)
				hitListener.Hit(_projectileController.Impact);

			var particleInstance = Instantiate(particle, transform.position, transform.rotation);
			Destroy(particleInstance, particleDuration);
			Destroy(gameObject);
		}
	}
}