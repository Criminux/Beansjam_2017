using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyAndInstanceCheck : MonoBehaviour {

    GameObject instance;

	void Start ()
    {
		if(instance == null)
        {
            instance = gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
	}
}
