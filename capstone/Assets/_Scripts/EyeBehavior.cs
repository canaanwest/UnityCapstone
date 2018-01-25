using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

public class EyeBehavior : MonoBehaviour
{
    GameObject focusedObj;
    GameObject getLevelManagerScript;
    GameObject displayScript; 
    
    //enum focusedObjectName {Tree, Bench, lampPost};

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

    void ReturnFocusedObject(GameObject currentFocused)
    {
        GameObject displayWordsScript = GameObject.Find("WordCatcher");
        displayWordsScript.SendMessage(currentFocused.name); 

    }


    IEnumerator WaitAndLoad()
    {
        while (focusedObj == null || focusedObj.name != "sack_010")
        {
            yield return null;
            print("You haven't hit the creation button yet");
        }

        GameObject currentFocusedObject = focusedObj;

        yield return new WaitForSecondsRealtime(2);

        if (focusedObj == currentFocusedObject)
        {
            print("You hit the creation button and I can execute a script now!!");
            LevelManager manageLevel = getLevelManagerScript.GetComponent<LevelManager>();
            manageLevel.LoadLevel("Creation");
            yield return new WaitForSecondsRealtime(1);
            StopCoroutine("WaitAndLoad");
        }
        else
        {
            StartCoroutine("WaitAndLoad");
        }
    
        print("DONE!!");
    }

    //the method below is not actually being executed in this script. There is some kind of mismatch in
    //the way the objects are being passed aroudn that i'm not sure about;

}
