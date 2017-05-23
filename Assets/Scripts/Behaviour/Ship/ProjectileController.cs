using System.Collections;
using System.Collections.Generic;
using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.GameObjects;
using UnityEngine;


namespace GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.Ship
{
	public class ProjectileController : MonoBehaviour
	{

		[SerializeField] float speed;

		[SerializeField] float lifetime;

		[SerializeField] float impact = ProjectileHitListener.ImpactHead;

        [SerializeField]
        AudioClip[] shotSounds;
        [SerializeField]
        float shotVolume;

        AudioSource audioSource;

		public float Impact
		{
			get { return impact; }
		}

		private Rigidbody body;

		void Start()
		{
			this.body = GetComponent<Rigidbody>();
            audioSource = GetComponent<AudioSource>();

            int toPlayIndex = Random.Range(0, shotSounds.Length);

            audioSource.PlayOneShot(shotSounds[toPlayIndex], shotVolume);
		}

		void Update()
		{
			move();
			checkLifeTime();
		}

		private void checkLifeTime()
		{
			lifetime -= Time.deltaTime;

			if (lifetime <= 0)
			{
				Destroy(gameObject);
			}
		}

		private void move()
		{
			body.velocity = transform.forward * speed;
		}
	}
}