﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
    public float speed = 5f;
    public float rotationTransform;
	// Use this for initialization
	void Start () {
     
	}
	
	// Update is called once per frame
	public void Update () {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rotationTransform -= 1;
            transform.rotation = Quaternion.Euler(0, rotationTransform, 0);
        } else if (Input.GetKey(KeyCode.RightArrow))
        {
            rotationTransform += 1;
            transform.rotation = Quaternion.Euler(0, rotationTransform, 0);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            //print("Up Arrow Down");
            if (transform.rotation.y > 0)
            {
                transform.position += new Vector3(0, 0, speed * Time.deltaTime);
            } else
            {
                transform.position += new Vector3(0, 0, -speed * Time.deltaTime);
            }
            
            
        } else if (Input.GetKey(KeyCode.DownArrow))
        {
            if (transform.rotation.y > 0)
            {
                transform.position += new Vector3(0, 0, -speed * Time.deltaTime);
            } else
            {
                transform.position += new Vector3(0, 0, speed * Time.deltaTime);
            }
        }
	}
}
