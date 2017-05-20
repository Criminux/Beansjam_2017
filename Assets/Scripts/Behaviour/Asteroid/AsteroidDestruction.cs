using System.Collections;
using System.Collections.Generic;
using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.GameObjects;
using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.Player;
using UnityEngine;

namespace GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.Asteroid
{

	public class AsteroidDestruction : MonoBehaviour
	{

		[SerializeField] GameObject pickUp;

		[SerializeField] private GameObject[] particles;
		[SerializeField] private float particleDuration = .5f;

		void Start()
		{
			GetComponent<ObjectHealth>().HealthReachedZero += Destruct;
		}

		private void Destruct()
		{
			Instantiate(pickUp, transform.position, Quaternion.identity);
			var selectedParticle = particles[Random.Range(0, particles.GetUpperBound(0))];

			var particleInstance = Instantiate(selectedParticle, transform.position, transform.rotation);
			Destroy(particleInstance, particleDuration);
			Destroy(gameObject);
		}
	}
}
