using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

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

        rigid.velocity = new Vector3(0,0,horizontal * speed);
        
        Debug.Log(rigid.velocity);
        
	}
}
