using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayWords : MonoBehaviour {
    public GameObject wordPrefab;
    public GameObject currentObjectShowingWords;
	
	// Update is called once per frame
	void Update () {
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
}
