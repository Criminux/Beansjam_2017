using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIThrustMaskController : MonoBehaviour {

    Rigidbody body;
    RectTransform trans;

    [SerializeField]
    float multi = 7.1f;
	
	void Start ()
    {
        body = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        trans = GetComponent<RectTransform>();
	}
	
	void Update ()
    {
        float relativeThrust = body.velocity.magnitude * multi;
        float top = (1070f - relativeThrust);
		trans.offsetMax = new Vector2(trans.offsetMax.x, -top);
    }
}
