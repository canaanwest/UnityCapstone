using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tobii.Gaming;
using UnityEngine.EventSystems;

public class NewMoveToNotebook : MonoBehaviour
{
    public GameObject wordsPrefab;
    private static int i;
    static GameObject getPoemBehaviorScript;
    static NewPoemBehavior newPoemBehavior;
    public GameObject focusedObject; 

    // Use this for initialization
    void Start()
    {
        getPoemBehaviorScript = GameObject.Find("CanvasR");
        newPoemBehavior = getPoemBehaviorScript.GetComponent<NewPoemBehavior>();
        i = -1;
        StartCoroutine("SaveWordEyeTrigger");
    }

    //Update is called once per frame
    void Update()
    {
        if (TobiiAPI.GetFocusedObject())
        {
            focusedObject = TobiiAPI.GetFocusedObject();
        }
    }

    private void OnMouseDown()
    {
        SelectWordForMovement();
    }

    void SelectWordForMovement()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100f) && hit.transform && hit.transform.gameObject.name == "textCollectionTemp(Clone)")
        {
            
            string word = hit.transform.gameObject.GetComponent<TextMesh>().text;
            if (i < 14)
            {
                i++;
            }
            else
            {
                i = 0;
            }


            newPoemBehavior.LoadWord(word, i);
        }
    }



    IEnumerator SaveWordEyeTrigger()
    {
        print("STARTED COROUTINE");
        while (focusedObject == null || focusedObject.name != "textCollectionTemp(Clone)")
        {
            yield return null;
        }

        print("FOUND AN OBJECT");

        GameObject selectObject;
        selectObject = focusedObject;

        yield return new WaitForSecondsRealtime(1);
        
        print("COMPARING OBJECTS!!");
        if (selectObject == focusedObject)
        {
            yield return new WaitForSecondsRealtime(1);
            if (selectObject == focusedObject)
            {
                if (i < 14)
                {
                    i++;
                }
                else
                {
                    i = 0;
                }


                newPoemBehavior.LoadWord(selectObject.GetComponent<TextMesh>().text, i);
                focusedObject = null;
                yield return new WaitForSecondsRealtime(2);
                StartCoroutine("SaveWordEyeTrigger");
            }
            else
            {
                StartCoroutine("SaveWordEyeTrigger");
            }
        }
        else
        {
            StartCoroutine("SaveWordEyeTrigger");
        }
    }
}








//right now i think that there is a problem with where the raycast is placed with the coroutine. I don't know why, but the raycast seems to be working in the update. 