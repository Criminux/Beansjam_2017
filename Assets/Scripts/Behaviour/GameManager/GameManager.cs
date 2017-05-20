using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.GameManager
{

	public class GameManager : MonoBehaviour
	{
		void Start()
		{
			DontDestroyOnLoad(gameObject);
		}
		
	}
}