using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotorSoundController : MonoBehaviour {

    [SerializeField]
    AudioSource motorSound;

    [SerializeField]
    float pitchDivisor;

    Rigidbody body;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        motorSound.pitch = body.velocity.magnitude / pitchDivisor;
	}
}
