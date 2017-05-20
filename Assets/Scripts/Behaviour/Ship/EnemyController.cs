using System;
using System.Collections;
using System.Collections.Generic;
using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.Player;
using GloriousWhale.BeansJam17.Assets.Scripts.Constants;
using JetBrains.Annotations;
using UnityEngine;


namespace GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.Ship
{
	public class EnemyController : MonoBehaviour, ShipMovement.InputProvider, ShipShooting.InputProvider
	{

		[SerializeField]
        private float distanceToKeep;

        [SerializeField]
        private float speed;

        [SerializeField]
        WeaponController[] weapons;


        private Transform playerTransform;

		void Start()
		{
            playerTransform = GameObject.FindGameObjectWithTag(Tags.Player).GetComponent<Transform>();
        }

        private void Update()
        {
            transform.LookAt(playerTransform);

            if(Vector3.Distance(transform.position, playerTransform.position) > distanceToKeep)
            {
                transform.position += transform.forward * speed;
            }
        }

		public float GetForwardInput()
		{
			return 0;
		}

		public float GetRollInput()
		{
			return 0;
		}

		public float GetYawInput()
		{
			return 0;
		}

		public float GetPitchInput()
		{
			return 0;
		}

		public bool GetShootingInput()
		{
			return Vector3.Distance(transform.position, playerTransform.position) <= distanceToKeep;
		}
	}
}