using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [SerializeField]
    float speed;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        transform.position = transform.position + (transform.forward * speed);
	}
}
