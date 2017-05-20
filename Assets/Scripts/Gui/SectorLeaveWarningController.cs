using System;
using System.Collections;
using System.Collections.Generic;
using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour;
using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.Player;
using GloriousWhale.BeansJam17.Assets.Scripts.Constants;
using UnityEngine;
using UnityEngine.UI;

namespace GloriousWhale.BeansJam17.Assets.Scripts.Gui
{
	public class SectorLeaveWarningController : MonoBehaviour
	{
		private const float FadingDuration_seconds = 1.0f;

		private Text text;

		// Use this for initialization
		void Start()
		{
			text = GetComponent<Text>();

			var player = GameObject.FindGameObjectWithTag(Tags.Player);
			var areaCheck = player.GetComponent<AreaCheck>();

			areaCheck.LeftLegalArea += OnLeftLegalArea;
			areaCheck.ReenteredLegalArea += AreaCheckOnReenteredLegalArea;
		}

		private void AreaCheckOnReenteredLegalArea()
		{
			text.CrossFadeAlpha(0, FadingDuration_seconds, false);
		}

		private void OnLeftLegalArea()
		{
			text.CrossFadeAlpha(1.0f, FadingDuration_seconds, false);
		}
	}
}