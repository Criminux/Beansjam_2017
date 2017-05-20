using System.Collections;
using System.Collections.Generic;
using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.Player;
using GloriousWhale.BeansJam17.Assets.Scripts.Constants;
using UnityEngine;


namespace GloriousWhale.BeansJam17.Assets.Scripts.Gui
{
	public class UiThrustMaskController : MonoBehaviour
	{

		private ShipMovement shipMovement;

		Rigidbody body;
		RectTransform rectTransform;
		
		private float originalHeight;

		void Start()
		{
			shipMovement = GameObject.FindGameObjectWithTag(Tags.Player).GetComponent<ShipMovement>();
			rectTransform = GetComponent<RectTransform>();

			originalHeight = rectTransform.rect.height;
		}

		void Update()
		{
			float relativeThrust = Mathf.Clamp01(Mathf.Abs(shipMovement.ForwardSpeed /shipMovement.MaxForwardSpeed));
			rectTransform.sizeDelta = new Vector2(rectTransform.rect.width,originalHeight * relativeThrust);
		}
	}
}
