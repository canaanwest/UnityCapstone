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
        print(Camera.main.transform.eulerAngles);
        if (TobiiAPI.GetFocusedObject())
        {
            focusedObj = TobiiAPI.GetFocusedObject();
        }

        print("Focused object is " + focusedObj);

        if (Input.GetMouseButtonDown(0))
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
        if (currentObjectShowingWords == targetObject)
            
        {
            print("HIT IS! this object");
            ClearWords();
            currentObjectShowingWords = null;
        }
        else if (currentObjectShowingWords != null)
        {
            ClearWords();
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
        //if (Physics.Raycast(ray, out hit, 100f) && hit.transform && hit.transform.Find("Words"))
        if (Physics.Raycast(ray, out hit, 100f) && hit.transform && hit.transform.gameObject.tag == "Playable")
        {

            if (currentObjectShowingWords == hit.transform.gameObject)
            {
                ClearWords();
                currentObjectShowingWords = null;
            }
            else if (currentObjectShowingWords != null)
            {
                ClearWords();
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
        if (currentObject.tag == "Playable")
        {
            print("^^^^^^^^^^^^ &&&&& this should be camera: " + Camera.main.transform.Find("Words"));
            Transform wordsObject = Camera.main.transform.Find("Words");
 
           foreach (Transform child in wordsObject)
            {
                print("CHILD! " + child);
                child.transform.eulerAngles = new Vector3(0, 0, 0);
                GameObject wordSpace = Instantiate(wordPrefab, child.transform.position, Quaternion.identity) as GameObject;
                
                print("^^^%^^^^^^^^" + child.transform.eulerAngles);
                wordSpace.transform.parent = child.transform;
                
                wordSpace.transform.parent.eulerAngles = new Vector3(0, Mathf.Abs(Camera.main.transform.eulerAngles.y), 0);
                print("Word angle is probably" + wordSpace.transform.eulerAngles);

            }
        }
    }

    void ClearWords()
        //this function clears the word from a position;

    {
        if (Camera.main.transform.Find("Words"))
        {
            //GameObject currentObject = myObj;
            Transform words = Camera.main.transform.Find("Words");

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
            yield return new WaitForSecondsRealtime(1);
            if (triggeredFocusedObject == focusedObj)
            {
                yield return new WaitForSecondsRealtime(1);
                if (triggeredFocusedObject == focusedObj)
                {
                    EyeClickDisplayWords(triggeredFocusedObject as GameObject);
                    yield return new WaitForSecondsRealtime(5);
                    print("I EXECUTED AND WAITED TWO SECONDS");

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
