using System.Collections;
using System.Collections.Generic;
using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.GameObjects;
using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.Player;
using UnityEngine;

namespace GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.Asteroid
{
	public class AsteroidHitListener : ProjectileHitListener
	{
		private ObjectHealth objectHealth;

		[SerializeField] private float demagePerImpact = 5;


		void Start()
		{
			objectHealth = GetComponent<ObjectHealth>();
		}


		public override void Hit(float impact)
		{
			objectHealth.Damage(demagePerImpact);
		}
	}
}
