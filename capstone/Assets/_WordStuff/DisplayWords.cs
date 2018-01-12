using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayWords : MonoBehaviour {
    public GameObject wordPrefab;
    public GameObject currentObjectShowingWords;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0))
        {
            emitEventkForObjectToDisplayWords();
        }
	}

    void emitEventkForObjectToDisplayWords()
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
    {
        GameObject currentObject = myObj;
        Transform words = currentObject.transform.Find("Words");
 
        foreach (Transform child in words.transform)
        {
            GameObject wordSpace = Instantiate(wordPrefab, child.transform.position, Quaternion.identity) as GameObject;
            wordSpace.transform.parent = child;
        }
    }

    void ClearWords( GameObject myObj)
    {
        GameObject currentObject = myObj;

        Transform words = currentObject.transform.Find("Words");
  
        foreach (Transform child in words.transform)
        {
            if (child.transform.GetChild(0).gameObject.name == "TextTemplate(Clone)")
            {
                Destroy(child.transform.GetChild(0).gameObject);
            } else
            {
                print("Nope");
            }


        }
    }
}
