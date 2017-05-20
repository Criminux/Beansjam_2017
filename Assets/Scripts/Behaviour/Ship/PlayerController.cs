using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.Player;
using UnityEngine;

namespace GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.Ship
{
	public class PlayerController : MonoBehaviour, ShipMovement.InputProvider, ShipShooting.InputProvider
	{

		public float GetForwardInput()
		{
			return Input.GetAxis(Constants.Input.AxisForward);
		}

		public float GetRollInput()
		{
			return Input.GetAxis(Constants.Input.AxisRoll);
		}

		public float GetYawInput()
		{
			return Input.GetAxis(Constants.Input.AxisMouseX);
		}

		public float GetPitchInput()
		{
			return Input.GetAxis(Constants.Input.AxisMouseY);
		}

		public bool GetShootingInput()
		{
			return Input.GetMouseButton(0);
		}
	}
}
