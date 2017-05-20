using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Behaviour.Player
{
	public abstract class ProjectileHitListener : MonoBehaviour
	{
		public const float InpactWeak = 1;
		public const float ImpactMedium = 2;
		public const float ImpactHead = 3;

		public abstract void Hit(float impact);
	}
}
