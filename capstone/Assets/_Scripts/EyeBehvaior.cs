using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

public class EyeBehvaior : MonoBehaviour {
    GameObject focusedObj; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        focusedObj = TobiiAPI.GetFocusedObject();
        print("Your focused Object is: " + focusedObj);
	}

    private void OnCollisionEnter(Collision collision)
    {
        print("I got a collision");
    }
}
