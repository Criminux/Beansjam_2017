using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GloriousWhale.BeansJam17.Assets.Scripts.Behaviour
{
	public class PlayerMovement : MonoBehaviour
	{

		[SerializeField]
		private float speed;

		private Rigidbody rigidbody;

		void Start()
		{
			rigidbody = GetComponent<Rigidbody>();
		}

		// Update is called once per frame
		void FixedUpdate()
		{
			var horizontal = Input.GetAxis(Constants.Input.AxisVertical);

			var mouseX = Input.GetAxis(Constants.Input.AxisMouseX);
			var mouseY = Input.GetAxis(Constants.Input.AxisMouseY);

			rigidbody.velocity = transform.forward * (horizontal * speed);

			transform.Rotate(new Vector3(-mouseY, mouseX));

			Debug.Log(rigidbody.velocity);

		}
	}
}