using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [SerializeField]
    float speed;

    [SerializeField]
    float lifetime;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        transform.position = transform.position + (transform.forward * speed);

        lifetime -= Time.deltaTime;

        if(lifetime <= 0)
        {
            Destroy(gameObject);
        }
	}
}
