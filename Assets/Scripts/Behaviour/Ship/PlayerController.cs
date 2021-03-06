﻿using System;
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

        private PlayerProperties playerProperties;
		private StationMenuController stationMenu;
        ShipProperties shipProperties;


		private void Start()
		{
			playerProperties = GetComponent<PlayerProperties>();
			stationMenu = GameObject.FindGameObjectWithTag(Tags.StationMenu).GetComponent<StationMenuController>();
			shipProperties = GetComponent<ShipProperties>();
		}

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
            if(shipProperties.Fuel > 0)
            {
                shipProperties.Fuel -= 1;

                int toLoadScene = UnityEngine.Random.Range(1, 8);

                transform.position = new Vector3(0, 0, 0);
            
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
                    case 7:
                        SceneManager.LoadScene(SceneTypes.Game_Nebula);
                        break;
                }
            }
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
            if (other.tag == Tags.SpaceStation && UnityEngine.Input.GetKeyDown(KeyCode.F) && !stationMenu.IsShowing)
            {
				stationMenu.Show();
            }
            if (other.tag == Tags.Civil && UnityEngine.Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("You're interacting with a Civil");
                if(other.GetComponent<CivilBehaviour>().HasPaid == false)
                {
                    playerProperties.Money += 10;
                    other.GetComponent<CivilBehaviour>().HasPaid = true;
                }
            }
            //TODO: Add more Interactables?
        }
    }
}
