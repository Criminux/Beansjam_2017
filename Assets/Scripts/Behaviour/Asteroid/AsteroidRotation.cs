using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.Asteroid
{
	public class AsteroidRotation : MonoBehaviour
	{

		[SerializeField] float rotationSpeedX;
		[SerializeField] float rotationSpeedY;
		[SerializeField] float rotationSpeedZ;
	

		void Update()
		{
			transform.Rotate(
				rotationSpeedX * Time.deltaTime, 
				rotationSpeedY * Time.deltaTime, 
				rotationSpeedZ * Time.deltaTime
			);
		}
	}
}