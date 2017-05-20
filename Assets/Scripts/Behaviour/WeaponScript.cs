using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {
    
    [SerializeField]
    GameObject projectile;
    [SerializeField]
    Transform projectileSpawn;
    GameObject Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Shoot()
    {
        Instantiate(projectile, projectileSpawn.position, Player.transform.rotation);
    }
    

}
