using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;


namespace GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.Camera
{

	public class TrackObject : MonoBehaviour
	{

		[SerializeField]
		private GameObject trackingObject;

		[SerializeField]
		private float distance;

		[SerializeField]
		private float rotationSpeed;

		[SerializeField]
		private float verticalOffset;

		[SerializeField]
		private float horizontalOffset;

		[SerializeField] private float roll;

		[SerializeField] private float pitch;

		[SerializeField] private float yaw;
		
		
		void LateUpdate()
		{
			var behingTrackingObjectByDistance = trackingObject.transform.position + (trackingObject.transform.forward * -1 * distance);
			var verticalOffsetVector = trackingObject.transform.up * verticalOffset;
			var horizontalOffsetVector = trackingObject.transform.right * horizontalOffset;
			transform.position = behingTrackingObjectByDistance + verticalOffsetVector + horizontalOffsetVector;

			var targetRotation = Quaternion.Euler(trackingObject.transform.rotation.eulerAngles + new Vector3(pitch, yaw, roll));

			transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
			
		}
	}
}
