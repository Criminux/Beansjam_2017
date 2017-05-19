using System;
using System.Collections;
using System.Collections.Generic;
using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour;
using UnityEngine;

namespace GloriousWhale.BeansJam17.Assets.Scripts.Behaviour
{

	public class LeaveAreaPunisher : MonoBehaviour
	{
		[SerializeField] private float healthDecreasePerSecond;

		private PlayerHealth playerHealth;
		private bool isPunishing;

		void Start()
		{
			playerHealth = GetComponent<PlayerHealth>();
			var areaCheck = GetComponent<AreaCheck>();
			areaCheck.LeftWarningArea += () => isPunishing = true;
			areaCheck.ReenteredWarningArea += () => isPunishing = false;
		}

		void Update()
		{
			if(isPunishing)
				playerHealth.Demage(healthDecreasePerSecond * Time.deltaTime);
		}
	}
}
