using System.Collections;
using System.Collections.Generic;
using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.GameObjects;
using UnityEngine;

public class ShipProjectileHitListener : ProjectileHitListener
{
	private ObjectHealth objectHealth;

	void Start () {
		objectHealth = GetComponent<ObjectHealth>();
	}


	public override void Hit(float impact)
	{
		objectHealth.Demage(impact *10);
	}
}
