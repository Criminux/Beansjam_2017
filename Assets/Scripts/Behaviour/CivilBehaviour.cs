using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivilBehaviour : MonoBehaviour {

    [SerializeField]
    Transform[] transforms;
    [SerializeField]
    float distanceToKeep;
    [SerializeField]
    float speed;

    private int currentTarget;

	void Start ()
    {
        currentTarget = 0;
	}
	
	void Update ()
    {
        transform.LookAt(transforms[currentTarget]);

        if (Vector3.Distance(transform.position, transforms[currentTarget].position) > distanceToKeep)
        {
            transform.position += transform.forward * speed;
            Debug.Log("Moving to Target");
        }
        else
        {
            Debug.Log("Switching Target");
            if(currentTarget == (transforms.Length - 1))
            {
                currentTarget = 0;
            }
            else
            {
                currentTarget++;
            }
        }
    }
}
