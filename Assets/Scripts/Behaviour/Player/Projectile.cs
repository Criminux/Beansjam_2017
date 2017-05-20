using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Behaviour.Player;
using UnityEngine;


namespace GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.Player
{
	public class Projectile : MonoBehaviour
	{

		[SerializeField] float speed;

		[SerializeField] float lifetime;

		[SerializeField] float impact = ProjectileHitListener.InpactWeak;

		public float Impact
		{
			get { return impact; }
		}

		void Update()
		{
			transform.position = transform.position + (transform.forward * speed);

			lifetime -= Time.deltaTime;

			if (lifetime <= 0)
			{
				Destroy(gameObject);
			}
		}
	}
}