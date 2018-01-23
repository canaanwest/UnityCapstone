using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

public class DisplayWords : MonoBehaviour {
    public GameObject wordPrefab;
    public GameObject currentObjectShowingWords;
    GameObject focusedObj;
    public GameObject spotlight; 



    private void Start()
    {
        spotlight.transform.position = new Vector3(-100, -100, -100);
        StartCoroutine("DisplayWordsForFocusedObject");
    }

    // Update is called once per frame
    void Update () {
        if (TobiiAPI.GetFocusedObject())
        {
            focusedObj = TobiiAPI.GetFocusedObject();
        }
        
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

                spotlight.transform.position = new Vector3(-100, -100, -100);
            }
            else if (currentObjectShowingWords != null)
            {
                ClearWords();
                currentObjectShowingWords = hit.transform.gameObject;
                LoadWords(currentObjectShowingWords);
                //GameObject light = GameObject.Find("Light");
                //light.transform.position = currentObjectShowingWords.transform.position;

                
                
                spotlight.transform.position = currentObjectShowingWords.transform.position;
                print("SPOTLIGHT IS " + spotlight);
                print("position is " + spotlight.transform.position);
            }
            else
            {
                currentObjectShowingWords = hit.transform.gameObject;
                LoadWords(hit.transform.gameObject);
               
                spotlight.transform.position = currentObjectShowingWords.transform.position;
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
            Transform wordsObject = Camera.main.transform.Find("Words");
 
           foreach (Transform child in wordsObject)
            {
                child.transform.eulerAngles = new Vector3(0, 0, 0);
                GameObject wordSpace = Instantiate(wordPrefab, child.transform.position, Quaternion.identity) as GameObject;
                wordSpace.transform.parent = child.transform;
                wordSpace.transform.parent.eulerAngles = new Vector3(0, Mathf.Abs(Camera.main.transform.eulerAngles.y), 0);
       
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

                    StartCoroutine("DisplayWordsForFocusedObject");
                } else
                {
                    StartCoroutine("DisplayWordsForFocusedObject");
                }
            } else
            {
                StartCoroutine("DisplayWordsForFocusedObject");
            }
        }
        else
        {
            StartCoroutine("DisplayWordsForFocusedObject");
        }

    }

}
