using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.Player
{
	/// <summary>
	/// See https://en.wikipedia.org/wiki/File:Flight_dynamics_with_text.png.
	/// </summary>
	public class PlayerMovement : MonoBehaviour
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
		/// How fast forward speed should decrease when receiving negative input.
		/// </summary>
		[SerializeField] private float forwardDeceleration;

		/// <summary>
		/// How fast forward speed should increase when receiving positive input. Should be positive since it gets multiplied with the negative input.
		/// </summary>
		[SerializeField] private float forwardAcceleration;

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


		public float ForwardSpeed { get; private set; }
		public float RollSpeed { get; private set; }
		public float YawSpeed { get; private set; }
		public float PitchSpeed { get; private set; }

		private Rigidbody body;

		void Start()
		{
			body = GetComponent<Rigidbody>();
		}
		
		void FixedUpdate()
		{
			UpdateForwardSpeed();
			UpdateRollSpeed();
			UpdateYawSpeed();
			UpdatePitchSpeed();

			body.velocity = transform.forward * ForwardSpeed;
			Debug.Log("Velocity: " + body.velocity);

			transform.Rotate(PitchSpeed, YawSpeed, RollSpeed);
		}

		private void UpdateForwardSpeed()
		{
			var forwardInput = Input.GetAxis(Constants.Input.AxisForward);

			var forwardAddition = forwardInput < 0.0f
				? forwardInput * forwardDeceleration * Time.deltaTime
				: forwardInput * forwardAcceleration * Time.deltaTime;

			ForwardSpeed = Mathf.Clamp(ForwardSpeed + forwardAddition, minForwardSpeed, maxForwardSpeed);
		}

		private void UpdateRollSpeed()
		{
			var rollInput = Input.GetAxis(Constants.Input.AxisRoll);
			var rollAddition = rollInput * rollAcceleration * Time.deltaTime;

			var updatedRollSpeed = RollSpeed;
			updatedRollSpeed = Mathf.Clamp(updatedRollSpeed + rollAddition, -maxRollSpeed, maxRollSpeed);
			updatedRollSpeed = Mathf.MoveTowards(updatedRollSpeed, 0.0f, Time.deltaTime * rollDecelration);
			RollSpeed = updatedRollSpeed;
		}

		private void UpdateYawSpeed()
		{
			var yawInput = Input.GetAxis(Constants.Input.AxisMouseX);
			var yawAddition = yawInput * yawAcceleration * Time.deltaTime;

			var updatedYawSpeed = YawSpeed;
			updatedYawSpeed = Mathf.Clamp(updatedYawSpeed + yawAddition, -maxYawSpeed, maxYawSpeed);
			updatedYawSpeed = Mathf.MoveTowards(updatedYawSpeed, 0.0f, Time.deltaTime * yawDecelration);
			YawSpeed = updatedYawSpeed;
		}

		private void UpdatePitchSpeed()
		{
			var pitchInput = Input.GetAxis(Constants.Input.AxisMouseY);
			var pitchAddition = pitchInput * pitchAcceleration * Time.deltaTime;

			var updatedPitchSpeed = PitchSpeed;
			updatedPitchSpeed = Mathf.Clamp(updatedPitchSpeed + pitchAddition, -maxPitchSpeed, maxPitchSpeed);
			updatedPitchSpeed = Mathf.MoveTowards(updatedPitchSpeed, 0.0f, Time.deltaTime * pitchDecelration);
			PitchSpeed = updatedPitchSpeed;
		}
	}
}