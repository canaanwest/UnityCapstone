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
        //this function directs the game to display or clear words based 
        //on the associated game object;
    {

        MouseClickDisplayWords();
    }

    void EyeClickDisplayWords(GameObject getWordsForThisObject)
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

        //GameObject getEyeBehaviorScriptObj = GameObject.Find("EyeBehaviorScript");
        //EyeBehvaior eyeBehaviorScript = getEyeBehaviorScriptObj.GetComponent<EyeBehvaior>();

        //GameObject focusedObject;
        //focusedObject = eyeBehaviorScript.DisplayWordsForFocusedObject();



        //This function is going to call upon another class method to decide if an eye click has been made;

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
        Transform wordsObject = currentObject.transform.Find("Words");
 
        foreach (Transform child in wordsObject.transform)
        {
            GameObject wordSpace = Instantiate(wordPrefab, child.transform.position, Quaternion.identity) as GameObject;
            wordSpace.transform.parent = child;
        }
    }

    void ClearWords( GameObject myObj)
        //this function clears the word from a position;

    {
        GameObject currentObject = myObj;
        Transform words = currentObject.transform.Find("Words");
  
        foreach (Transform child in words.transform)
        {
            if (child.transform.Find("TextTemplate(Clone)").gameObject)
            {
                Destroy(child.transform.Find("TextTemplate(Clone)").gameObject);
            } else
            {
                print("Nope");
            }
        }
    }

    public IEnumerator DisplayWordsForFocusedObject()
    {
        while (focusedObj == null)
        {
            yield return null;
            print("You haven't looked at a word associated object yet");
        }

        print("YOU FOCUSED ON AN OBJECT GOOD BOY");
        GameObject triggeredFocusedObject = focusedObj;

        yield return new WaitForSecondsRealtime(3);
        if (triggeredFocusedObject == focusedObj)
        {
            print("TRYING TO CLICK");
            EyeClickDisplayWords(focusedObj);
            StartCoroutine("DisplayWordsForFocusedObject");
        }
        else
        {

            StartCoroutine("DisplayWordsForFocusedObject");
            //DisplayWordsForFocusedObject();
        }
    }
}
