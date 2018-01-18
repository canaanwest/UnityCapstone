using System.Collections;
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
        if (TobiiAPI.GetFocusedObject())
        {
            focusedObj = TobiiAPI.GetFocusedObject();
        }

        print("Focused object is " + focusedObj);

        if (Input.GetMouseButtonUp(0))
        {
            emitEventForObjectToDisplayWords();
        }
	}

    void emitEventForObjectToDisplayWords()
    {

        MouseClickDisplayWords();
    }

    public void EyeClickDisplayWords(GameObject targetObject)
        //input is a game object.
    {
        if ((currentObjectShowingWords == targetObject))
            
        {
            ClearWords(currentObjectShowingWords);
            currentObjectShowingWords = null;
        }
        else if ((currentObjectShowingWords != null))
        {
            ClearWords(currentObjectShowingWords);
            currentObjectShowingWords = targetObject;
            LoadWords(currentObjectShowingWords);
        }
        else
        {
            currentObjectShowingWords = targetObject;
            LoadWords(currentObjectShowingWords);
        }
    }

    void MouseClickDisplayWords()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100f) && hit.transform && hit.transform.Find("Words"))
        {
            print("Hit is: " + hit);
            print("Hit.transform is " + hit.transform);
            print("Hit.transform.gameObject is " + hit.transform.gameObject);
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
        while (focusedObj == null || focusedObj.name == "sack_010" || focusedObj.name == "TextTemplate(Clone)")
        {
            yield return null;
            print("You haven't looked at a word associated object yet");
        }
        
        GameObject triggeredFocusedObject = focusedObj;
        yield return new WaitForSecondsRealtime(.5f);
        if (triggeredFocusedObject == focusedObj)
        {
            yield return new WaitForSecondsRealtime(1f);
            if (triggeredFocusedObject == focusedObj)
            {
                yield return new WaitForSecondsRealtime(1);
                if (triggeredFocusedObject == focusedObj)
                {
                    EyeClickDisplayWords(triggeredFocusedObject as GameObject);
                    yield return new WaitForSecondsRealtime(2);
                    StartCoroutine("DisplayWordsForFocusedObject");
                } else
                {
                    StartCoroutine("DisplayWordsForFocusedObject");
                }
            } else
            {
                StartCoroutine("DisplayWordsForFocusedObject");
            }
            print("TRYING TO CLICK ON " + focusedObj);
        }
        else
        {
            StartCoroutine("DisplayWordsForFocusedObject");
        }

    }

}
