using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    float speed;
    Rigidbody rigid;

	void Start ()
    {
        rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float horizontal = Input.GetAxis("Vertical");

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        rigid.velocity = transform.forward * (horizontal * speed);

        transform.Rotate(new Vector3(-mouseY, mouseX));
        
        Debug.Log(rigid.velocity);
        
	}
}
