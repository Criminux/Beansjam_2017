using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidBehaviour : MonoBehaviour {

    [SerializeField]
    float rotationSpeedX;
    [SerializeField]
    float rotationSpeedY;
    [SerializeField]
    float rotationSpeedZ;

    [SerializeField]
    bool rotateX;
    [SerializeField]
    bool rotateY;
    [SerializeField]
    bool rotateZ;

    
	
	// Update is called once per frame
	void Update ()
    {
        if (rotateX) { transform.Rotate(rotationSpeedX, 0, 0); }
        if (rotateY) { transform.Rotate(0, rotationSpeedY, 0); }
        if (rotateZ) { transform.Rotate(0, 0, rotationSpeedZ); }
	}
}
