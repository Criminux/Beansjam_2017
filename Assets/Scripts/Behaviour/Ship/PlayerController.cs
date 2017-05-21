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

        PlayerProperties playerProperties;

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
            int toLoadScene = UnityEngine.Random.Range(1, 7);
            
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
                case 4:
                    SceneManager.LoadScene(SceneTypes.Game_Police);
                    break;
                case 5:
                    SceneManager.LoadScene(SceneTypes.Game_SpaceStation);
                    break;
                case 6:
                    SceneManager.LoadScene(SceneTypes.Game_Civil);
                    break;
            }
              
            
        }

        private void Start()
        {
            playerProperties = GetComponent<PlayerProperties>();   
        }

        private void OnTriggerStay(Collider other)
        {
            if(other.tag == Tags.Bar && UnityEngine.Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("You're interacting with a Bar");
                if(playerProperties.Money >= 25)
                {
                    playerProperties.Money -= 25;
                    playerProperties.Crew += 1;
                }
            }
            if (other.tag == Tags.SpaceStation && UnityEngine.Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("You're interacting with a Station");
                //if (playerProperties.Money >= 25)
                //{
                //    playerProperties.Money -= 25;
                //    playerProperties.Crew += 1;
                //}
            }
            //TODO: Add more Interactables?
        }
    }
}
