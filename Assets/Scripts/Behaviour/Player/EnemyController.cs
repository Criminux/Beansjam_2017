using System;
using System.Collections;
using System.Collections.Generic;
using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.Player;
using GloriousWhale.BeansJam17.Assets.Scripts.Constants;
using JetBrains.Annotations;
using UnityEngine;

public class EnemyController : MonoBehaviour, ShipMovement.InputProvider, ShipShooting.InputProvider
{
	[CanBeNull]
	public GameObject AttackingObject
	{
		get; private set;
	}

	void Start () {
		AttackingObject = GameObject.FindGameObjectWithTag(Tags.Player); 
	}

	public float GetForwardInput()
	{
		return 0;
	}

	public float GetRollInput()
	{
		return GetRotationDeltaToAttackingObject().z;
	}

	public float GetYawInput()
	{
		return GetRotationDeltaToAttackingObject().y;
	}

	public float GetPitchInput()
	{
		return GetRotationDeltaToAttackingObject().x;
	}

	private Vector3 GetRotationDeltaToAttackingObject()
	{
		var positionDelta = AttackingObject.transform.position - transform.position;
		var targetRotation = Quaternion.LookRotation(positionDelta, Vector3.forward);

		return targetRotation.eulerAngles - transform.rotation.eulerAngles;
	}

	public bool GetShootingInput()
	{
		return true;
		if (AttackingObject == null)
		{
			return false;
		}
		else
		{
			Ray ray = new Ray(transform.position, transform.forward);
			RaycastHit hit;
			var raycast = Physics.Raycast(ray, out hit);
			// TODO: Find some other way to check if the hit object is the attacking object.
			return hit.collider != null && hit.collider.tag == AttackingObject.tag;
		}
	}
}
