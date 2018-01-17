using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

public class EyeBehvaior : MonoBehaviour
{
    GameObject focusedObj;
    GameObject getLevelManagerScript;
 
    // Use this for initialization
    void Start()
    {
        getLevelManagerScript = GameObject.Find("LevelManager");
        StartCoroutine("WaitAndLoad");
    }

    // Update is called once per frame
    void Update()
    {
        focusedObj = TobiiAPI.GetFocusedObject();
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("I got a collision");
    }

    IEnumerator WaitAndLoad()
    {
        while (focusedObj == null || focusedObj.name != "sack_010")
        {
            yield return null;
            print("You haven't hit the creation button yet");
        }


        yield return new WaitForSeconds(5);

        if (focusedObj != null && focusedObj.name == "sack_010")
        {
            //LoadLevel("Creation");
            print("You hit the creation button and I can execute a script now!!");
            LevelManager manageLevel = getLevelManagerScript.GetComponent<LevelManager>();
            manageLevel.LoadLevel("Creation");

            StopCoroutine("WaitAndLoad");

        }
        else
        {
            StartCoroutine("WaitAndLoad");
        }

        //GameObject delayedFocus = TobiiAPI.GetFocusedObject();
        // suspend execution for 5 seconds

        print("DONE!!");
    }
}
