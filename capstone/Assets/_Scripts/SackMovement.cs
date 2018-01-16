using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SackMovement : MonoBehaviour {
    Vector3 cameraFollowOffset = new Vector3(5, 1, 5);
    Camera followingCamera;

    // Use this for initialization
    void Start () {
        followingCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        print(followingCamera.transform.position);
        print(followingCamera.transform.eulerAngles);

        this.transform.position = followingCamera.transform.position + cameraFollowOffset;
	}
}
