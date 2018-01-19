using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;
using UnityEngine.UI;

public class SavingOldCode : MonoBehaviour {
    Vector3 gazeLocation;
    
	// Use this for initialization
	void Start () {
        gazeLocation = TobiiAPI.GetGazePoint().Screen;
            
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator savingOldCode()
    {
        RaycastHit2D hit = Physics2D.Raycast(gazeLocation, new Vector2(0, 0));
        print("hit collider is " + hit.collider);
        //Debug.DrawLine(new Vector3(gazeLocation.x + 3f, gazeLocation.y + 10), new Vector2(0, 0));

        while (hit.collider == null)
        {
            print("no collider");
            yield return null;
        }

        print("HIT!");
        Vector3 gotAFocusOn = gazeLocation;
        yield return new WaitForSecondsRealtime(1);
        print("I waited for one second.");
        if (gotAFocusOn.x - gazeLocation.x <= Mathf.Abs(5f) && gotAFocusOn.y - gazeLocation.y <= Mathf.Abs(5f))
        {
            print("You held gaze for one second!");
            yield return new WaitForSecondsRealtime(1);
            if (gotAFocusOn.x - gazeLocation.x <= Mathf.Abs(5f) && gotAFocusOn.y - gazeLocation.y <= Mathf.Abs(5f))
            {
                print("TWO seconds");

                string newWord = hit.collider.transform.GetComponent<Text>().text;
               // LoadWord(newWord, i);
               // i++; //external variable controlling position of word;

                StartCoroutine("GetGazePoint");
            }
            else
            {
                StartCoroutine("GetGazePoint");
            }
        }
        else
        {
            StartCoroutine("GetGazePoint");
        }
    }
}

