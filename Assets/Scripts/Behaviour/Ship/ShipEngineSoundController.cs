using System.Collections;
using System.Collections.Generic;
using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.Player;
using UnityEngine;

namespace GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.Ship
{

	public class ShipEngineSoundController : MonoBehaviour
	{

		[SerializeField] AudioSource engineSoundSource;

		[SerializeField] float pitchDivisor;

		Rigidbody body;
		private ShipMovement shipMovement;

		// Use this for initialization
		void Start()
		{
			body = GetComponent<Rigidbody>();
			shipMovement = GetComponent<ShipMovement>();
		}

		// Update is called once per frame
		void Update()
		{
			engineSoundSource.pitch = shipMovement.ForwardSpeed / pitchDivisor;
		}
	}
}