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
		
		
		void LateUpdate()
		{
			var behingTrackingObjectByDistance = trackingObject.transform.position + (trackingObject.transform.forward * -1 * distance);
			var verticalOffsetVector = trackingObject.transform.up * verticalOffset;
			transform.position = behingTrackingObjectByDistance + verticalOffsetVector;

			transform.rotation = Quaternion.RotateTowards(transform.rotation, trackingObject.transform.rotation, rotationSpeed * Time.deltaTime);
			
		}
	}
}
