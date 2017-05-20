using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Behaviour.Player;
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
			objectHealth.Demage(demagePerImpact);
		}
	}
}
