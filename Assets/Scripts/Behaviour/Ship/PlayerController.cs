using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.Player;
using GloriousWhale.BeansJam17.Assets.Scripts.Constants;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.Ship
{
	public class PlayerController : MonoBehaviour, ShipMovement.InputProvider, ShipShooting.InputProvider
	{

		public float GetForwardInput()
		{
			return UnityEngine.Input.GetAxis(Constants.Input.AxisForward);
		}

		public float GetRollInput()
		{
			return UnityEngine.Input.GetAxis(Constants.Input.AxisRoll);
		}

		public float GetYawInput()
		{
			return UnityEngine.Input.GetAxis(Constants.Input.AxisMouseX);
		}

		public float GetPitchInput()
		{
			return UnityEngine.Input.GetAxis(Constants.Input.AxisMouseY);
		}

		public bool GetShootingInput()
		{
			return UnityEngine.Input.GetMouseButton(0);
		}


        private void Update()
        {
            if(UnityEngine.Input.GetKeyDown(KeyCode.J))
            {
                InitiateJump();
            }
        }

        private void InitiateJump()
        {
            //TODO: Make Countdown
            int toLoadScene = UnityEngine.Random.Range(1, 4);
            
            switch (toLoadScene)
            {
                case 1:
                    SceneManager.LoadScene(SceneTypes.Game_Asteroid);
                    break;
                case 2:
                    SceneManager.LoadScene(SceneTypes.Game_Bar);
                    break;
                case 3:
                    SceneManager.LoadScene(SceneTypes.Game_Enemy);
                    break;
            }
              
            
        }
    }
}
