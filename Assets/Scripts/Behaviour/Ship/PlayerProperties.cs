using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.Ship
{
	public class PlayerProperties : MonoBehaviour
	{
		[SerializeField] private double initialMoney = 100;
		[SerializeField] private int initialCrew = 3;

		public double Money { get; set; }

		public int Crew { get; set; }

		void Start()
		{
			Money = initialMoney;
			Crew = initialCrew;
		}
	}
}
