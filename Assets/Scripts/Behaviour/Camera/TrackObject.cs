using System.Collections;
using System.Collections.Generic;
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
		
		
		void LateUpdate()
		{
			var behingTrackingObjectByDistance = trackingObject.transform.position + (trackingObject.transform.forward * -1 * distance);
			var verticalOffsetVector = trackingObject.transform.up * verticalOffset;
			var horizontalOffsetVector = trackingObject.transform.right * horizontalOffset;
			transform.position = behingTrackingObjectByDistance + verticalOffsetVector + horizontalOffsetVector;

			transform.rotation = Quaternion.RotateTowards(transform.rotation, trackingObject.transform.rotation, rotationSpeed * Time.deltaTime);
			
		}
	}
}
