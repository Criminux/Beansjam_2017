
using System;
using GloriousWhale.BeansJam17.Assets.Scripts.Constants;
using UnityEngine;

namespace GloriousWhale.BeansJam17.Assets.Scripts.Behaviour
{

	public class AreaCheck : MonoBehaviour
	{

		private GameObject player;
		private GameObject legalArea;
		private GameObject warningArea;

		void Start()
		{
			player = GameObject.FindGameObjectWithTag(Tags.Player);
			legalArea = GameObject.FindGameObjectWithTag(Tags.LegalArea);
			warningArea = GameObject.FindGameObjectWithTag(Tags.WarningArea);
		}
		

		void LateUpdate()
		{
			Console.WriteLine("Blubb");
		}
	}
}