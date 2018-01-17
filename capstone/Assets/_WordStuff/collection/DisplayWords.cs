﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

public class DisplayWords : MonoBehaviour {
    public GameObject wordPrefab;
    public GameObject currentObjectShowingWords;
    GameObject focusedObj;



    private void Start()
    {
        StartCoroutine("DisplayWordsForFocusedObject");
    }

    // Update is called once per frame
    void Update () {
        focusedObj = TobiiAPI.GetFocusedObject();
        print("Focused object is " + focusedObj);
        //this function says if there's a mouseclick, emit an event
        //so that an object knows to display words;
        if (Input.GetMouseButtonUp(0))
        {
            emitEventForObjectToDisplayWords();
        }
	}

    void emitEventForObjectToDisplayWords()
    {

        MouseClickDisplayWords();
    }

    public void EyeClickDisplayWords(GameObject getWordsForThisObject)
    {
        if ((currentObjectShowingWords == getWordsForThisObject))
        {
            ClearWords(getWordsForThisObject);
            currentObjectShowingWords = null;
        }
        else if ((currentObjectShowingWords != null))
        {
            ClearWords(currentObjectShowingWords);
            currentObjectShowingWords = getWordsForThisObject;
            LoadWords(getWordsForThisObject);
        }
        else
        {
            currentObjectShowingWords = getWordsForThisObject;
            LoadWords(getWordsForThisObject);
        }
    }

    void MouseClickDisplayWords()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100f) && hit.transform && hit.transform.Find("Words"))
        {
            if ((currentObjectShowingWords == hit.transform.gameObject))
            {
                ClearWords(currentObjectShowingWords);
                currentObjectShowingWords = null;
            }
            else if ((currentObjectShowingWords != null))
            {
                ClearWords(currentObjectShowingWords);
                currentObjectShowingWords = hit.transform.gameObject;
                LoadWords(currentObjectShowingWords);
            }
            else
            {
                currentObjectShowingWords = hit.transform.gameObject;
                LoadWords(hit.transform.gameObject);
            }

        }
    }

    public void LoadWords (GameObject myObj)
        //this function locates the object upon which to load words within
        //the game and then loads the words to the game.
        //where is it getting the words? freaky.
    {
        GameObject currentObject = myObj;
        if (currentObject.transform.Find("Words"))
        {
            Transform wordsObject = currentObject.transform.Find("Words");
 
           foreach (Transform child in wordsObject.transform)
            {
                GameObject wordSpace = Instantiate(wordPrefab, child.transform.position, Quaternion.identity) as GameObject;
                wordSpace.transform.parent = child;
            }
        }
    }

    void ClearWords( GameObject myObj)
        //this function clears the word from a position;

    {
        if (myObj.transform.Find("Words"))
        {
            GameObject currentObject = myObj;
            Transform words = currentObject.transform.Find("Words");

            foreach (Transform child in words.transform)
            {
                if (child.transform.Find("TextTemplate(Clone)").gameObject)
                {
                    Destroy(child.transform.Find("TextTemplate(Clone)").gameObject);
                }
                else
                {
                    print("Nope");
                }
            }
        }
    }

    public IEnumerator DisplayWordsForFocusedObject()
    {
        while (focusedObj == null || focusedObj.name == "sack_010")
        {
            yield return null;
            print("You haven't looked at a word associated object yet");
        }

        print("YOU FOCUSED ON AN OBJECT GOOD BOY");
        GameObject triggeredFocusedObject = focusedObj;

        yield return new WaitForSecondsRealtime(2);
        if (triggeredFocusedObject == focusedObj)
        {
            print("TRYING TO CLICK ON " + focusedObj);

            EyeClickDisplayWords(triggeredFocusedObject);
            StartCoroutine("DisplayWordsForFocusedObject");
        }
        else
        {
            StartCoroutine("DisplayWordsForFocusedObject");
        }

    }

}
