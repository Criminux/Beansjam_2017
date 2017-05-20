using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.GameManager
{

	public class GameManager : MonoBehaviour
	{

		public static int money = 100;
		public static int fuel = 10;
		public static int crew = 3;
		public static int ammo = 25;

		// Use this for initialization
		void Start()
		{
			DontDestroyOnLoad(gameObject);
		}

		// Update is called once per frame
		void Update()
		{

		}
	}
}