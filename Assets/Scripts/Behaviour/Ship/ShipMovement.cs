using System;
using System.Collections;
using System.Collections.Generic;
using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.GameObjects;
using UnityEngine;

namespace GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.Player
{
	/// <summary>
	/// See https://en.wikipedia.org/wiki/File:Flight_dynamics_with_text.png.
	/// </summary>
	public class ShipMovement : MonoBehaviour
	{
		/// <summary>
		/// The minimum forward speed. Should be negative.
		/// </summary>
		[SerializeField] private float minForwardSpeed;

		/// <summary>
		/// The maximum forward speed. Should be positive and way larger than <see cref="minForwardSpeed"/>.
		/// </summary>
		[SerializeField] private float maxForwardSpeed;

		/// <summary>
		/// How fast forward speed should decrease when receiving negative input. Should be positive since it gets multiplied with the negative input.
		/// </summary>
		[SerializeField] private float forwardDeceleration;

		/// <summary>
		/// How fast forward speed should increase when receiving positive input. 
		/// </summary>
		[SerializeField] private float forwardAcceleration;

		[SerializeField] private float forwardAccelerationSpeed;

		/// <summary>
		/// The maximum roll speed in both directions.  Will not be reached because of <see cref="rollDecelration"/>.
		/// </summary>
		[SerializeField] private float maxRollSpeed;

		/// <summary>
		/// How fast the roll should increase when receiving input. 
		/// </summary>
		[SerializeField] private float rollAcceleration;

		/// <summary>
		/// How fast the pitch should automatically decelerate.
		/// </summary>
		[SerializeField] private float rollDecelration;

		/// <summary>
		/// The maximum yaw speed in both directions. Will not be reached because of <see cref="yawDecelration"/>.
		/// </summary>
		[SerializeField] private float maxYawSpeed;

		/// <summary>
		/// How fast the yaw should increase when receiving input.
		/// </summary>
		[SerializeField] private float yawAcceleration;

		/// <summary>
		/// How fast the pitch should automatically decelerate.
		/// </summary>
		[SerializeField] private float yawDecelration;

		/// <summary>
		/// The maximum pitch speed in both directions. Will not be reached because of <see cref="pitchDecelration"/>.
		/// </summary>
		[SerializeField] private float maxPitchSpeed;

		/// <summary>
		/// How fast the pitch should increase when receiving input.
		/// </summary>
		[SerializeField] private float pitchAcceleration;

		/// <summary>
		/// How fast the pitch should automatically decelerate.
		/// </summary>
		[SerializeField] private float pitchDecelration;

		[SerializeField] private float collisionKnockback;

		[SerializeField] private int demageOnCollision;


		public float ForwardSpeed { get; private set; }
		public float RollSpeed { get; private set; }
		public float YawSpeed { get; private set; }
		public float PitchSpeed { get; private set; }

		private Rigidbody body;
		private InputProvider inputProvider;
		private ObjectHealth objectHealth;

		void Start()
		{
			body = GetComponent<Rigidbody>();
			objectHealth = GetComponent<ObjectHealth>();
			inputProvider = GetComponent<InputProvider>();
		}
		
		void FixedUpdate()
		{
			UpdateForwardSpeed(Mathf.Clamp(inputProvider.GetForwardInput(), -1, 1));
			UpdateRollSpeed(Mathf.Clamp(inputProvider.GetRollInput(), -1, 1));
			UpdateYawSpeed(Mathf.Clamp(inputProvider.GetYawInput(), -1, 1));
			UpdatePitchSpeed(Mathf.Clamp(inputProvider.GetPitchInput(), -1, 1));

			body.velocity = transform.forward * ForwardSpeed;
			transform.Rotate(PitchSpeed, YawSpeed, RollSpeed);
		}

		void OnCollisionEnter(Collision collision)
		{
			ForwardSpeed = -collisionKnockback;
			objectHealth.Demage(demageOnCollision);
		}

		private void UpdateForwardSpeed(float input)
		{
			var forwardAddition = input < 0.0f
				? input * forwardDeceleration * Time.deltaTime
				: input * forwardAcceleration * Time.deltaTime;

			var targetSpeed = Mathf.Clamp(ForwardSpeed + forwardAddition, minForwardSpeed, maxForwardSpeed);
			ForwardSpeed = Mathf.Lerp(ForwardSpeed, targetSpeed, Time.deltaTime * forwardAccelerationSpeed);
		}

		private void UpdateRollSpeed(float input)
		{
			var rollAddition = input * rollAcceleration * Time.deltaTime;

			var updatedRollSpeed = RollSpeed;
			updatedRollSpeed = Mathf.Clamp(updatedRollSpeed + rollAddition, -maxRollSpeed, maxRollSpeed);
			updatedRollSpeed = Mathf.MoveTowards(updatedRollSpeed, 0.0f, Time.deltaTime * rollDecelration);
			RollSpeed = updatedRollSpeed;
		}

		private void UpdateYawSpeed(float input)
		{
			var yawAddition = input * yawAcceleration * Time.deltaTime;

			var updatedYawSpeed = YawSpeed;
			updatedYawSpeed = Mathf.Clamp(updatedYawSpeed + yawAddition, -maxYawSpeed, maxYawSpeed);
			updatedYawSpeed = Mathf.MoveTowards(updatedYawSpeed, 0.0f, Time.deltaTime * yawDecelration);
			YawSpeed = updatedYawSpeed;
		}

		private void UpdatePitchSpeed(float input)
		{
			var pitchAddition = input * pitchAcceleration * Time.deltaTime;

			var updatedPitchSpeed = PitchSpeed;
			updatedPitchSpeed = Mathf.Clamp(updatedPitchSpeed + pitchAddition, -maxPitchSpeed, maxPitchSpeed);
			updatedPitchSpeed = Mathf.MoveTowards(updatedPitchSpeed, 0.0f, Time.deltaTime * pitchDecelration);
			PitchSpeed = updatedPitchSpeed;
		}

		public interface InputProvider
		{
			float GetForwardInput();
			float GetRollInput();
			float GetYawInput();
			float GetPitchInput();
		}
	}
}