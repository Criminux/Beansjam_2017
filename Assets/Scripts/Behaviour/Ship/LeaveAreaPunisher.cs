using System;
using System.Collections;
using System.Collections.Generic;
using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour;
using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.GameObjects;
using UnityEngine;

namespace GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.Ship
{

	public class LeaveAreaPunisher : MonoBehaviour
	{
		[SerializeField] private float healthDecreasePerSecond;

		private ObjectHealth _objectHealth;
		private bool isPunishing;

		void Start()
		{
			_objectHealth = GetComponent<ObjectHealth>();
			var areaCheck = GetComponent<AreaCheck>();
			areaCheck.LeftWarningArea += () => isPunishing = true;
			areaCheck.ReenteredWarningArea += () => isPunishing = false;
		}

		void Update()
		{
			if(isPunishing)
				_objectHealth.Damage(healthDecreasePerSecond * Time.deltaTime);
		}
	}
}
