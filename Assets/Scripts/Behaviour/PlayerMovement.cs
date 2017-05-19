using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GloriousWhale.BeansJam17.Assets.Scripts.Behaviour
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

		[SerializeField] private float maxForwardSpeed;

		[SerializeField] private float forwardDeceleration;

		[SerializeField] private float forwardAcceleration;

		/// <summary>
		/// The maximum roll speed in both directions.
		/// </summary>
		[SerializeField] private float maxRollSpeed;

		[SerializeField] private float rollAcceleration;

		/// <summary>
		/// The maximum yaw speed in both directions.
		/// </summary>
		[SerializeField] private float maxYawSpeed;

		[SerializeField] private float yawAcceleration;

		/// <summary>
		/// The maximum pitch speed in both directions.
		/// </summary>
		[SerializeField] private float maxPitchSpeed;

		[SerializeField] private float pitchAcceleration;


		public float ForwardSpeed { get; private set; }
		public float RollSpeed { get; private set; }
		public float YawSpeed { get; private set; }
		public float PitchSpeed { get; private set; }

		private Rigidbody rigidbody;

		void Start()
		{
			rigidbody = GetComponent<Rigidbody>();
		}

		// Update is called once per frame
		void FixedUpdate()
		{
			UpdateForwardSpeed();
			UpdateRollSpeed();
			UpdateYawSpeed();
			UpdatePitchSpeed();

			rigidbody.velocity = transform.forward * ForwardSpeed;
			Debug.Log("Velocity: " + rigidbody.velocity);

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
			RollSpeed = Mathf.Clamp(RollSpeed + rollAddition, -maxRollSpeed, maxRollSpeed);
		}

		private void UpdateYawSpeed()
		{
			var yawInput = Input.GetAxis(Constants.Input.AxisMouseX);
			var yawAddition = yawInput * yawAcceleration * Time.deltaTime;
			YawSpeed = Mathf.Clamp(YawSpeed + yawAddition, -maxYawSpeed, maxYawSpeed);
		}

		private void UpdatePitchSpeed()
		{
			var pitchInput = Input.GetAxis(Constants.Input.AxisMouseY);
			var pitchAddition = pitchInput * pitchAcceleration * Time.deltaTime;
			PitchSpeed = Mathf.Clamp(PitchSpeed + pitchAddition, -maxPitchSpeed, maxPitchSpeed);
		}
	}
}