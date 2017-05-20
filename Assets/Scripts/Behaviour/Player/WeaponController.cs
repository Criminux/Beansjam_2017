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

        bool canShoot;

		private void Start()
		{
            canShoot = true;
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
                cooldownTimer = shotCooldown;
            }
		}

	}
}