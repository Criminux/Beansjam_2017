using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.Player
{
	public class WeaponScript : MonoBehaviour
	{

		[SerializeField] GameObject projectile;
		[SerializeField] Transform projectileSpawn;
		GameObject player;

        [SerializeField]
        float shotCooldown;
        float cooldownTimer = 0;

        private PlayerShotSoundController soundcontroller;

        bool canShoot;

		private void Start()
		{
			player = GameObject.FindGameObjectWithTag("Player");
            canShoot = true;
            soundcontroller = player.GetComponent<PlayerShotSoundController>();

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
			    Instantiate(projectile, projectileSpawn.position, player.transform.rotation);
                cooldownTimer = shotCooldown;
                soundcontroller.PlayOneShot();
            }
		}

	}
}