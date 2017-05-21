using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.Ship;
using GloriousWhale.BeansJam17.Assets.Scripts.Constants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.Player
{
	public class WeaponController : MonoBehaviour
	{

		[SerializeField] GameObject projectile;
		[SerializeField] Transform projectileSpawn;

        [SerializeField]
        float shotCooldown;
        float cooldownTimer = 0;

        [SerializeField]
        float crewMulitplier = 0.2;

        PlayerProperties playerProperties;

        bool canShoot;

		private void Start()
		{
            canShoot = true;
            playerProperties = GameObject.FindGameObjectWithTag(Tags.Player).GetComponent<PlayerProperties>();
		}

        private void Update()
        {
            if(cooldownTimer > 0)
            {
                cooldownTimer -= Time.deltaTime;
                canShoot = false;
            }
            else
            {
                canShoot = true;
            }
        }

        public void Shoot()
		{
            if(canShoot)
            {
			    Instantiate(projectile, projectileSpawn.position, projectileSpawn.transform.rotation);
                cooldownTimer = shotCooldown * (playerProperties.Crew * crewMulitplier);
            }
		}

	}
}