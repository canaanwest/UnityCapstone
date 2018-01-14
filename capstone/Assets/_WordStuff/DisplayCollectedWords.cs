using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayCollectedWords : MonoBehaviour
{
    public GameObject wordPrefab;
    public string[] pouchWords; 
    private void Start()
    {
       GameObject getCollectedScript = GameObject.Find("PouchWords");
       SaveWord savedWords = getCollectedScript.GetComponent<SaveWord>();
        print("Saved Words: " + savedWords.ReturnCollected());
       pouchWords = savedWords.ReturnCollected().Split(new char[] {});

        foreach (string word in pouchWords)
        {
            print("pouchwords: " + word);
            //attach word to position;
        }
        
       // DisplayWords displayCollectedWords = getCollectedScript.GetComponent<collectedWords>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 10);
    }

    
    public GameObject currentObjectShowingWords;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            emitEventkForObjectToDisplayWords();
        }
    }

    void emitEventkForObjectToDisplayWords()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100f) && hit.transform && hit.transform.Find("Collected"))
        {

        }
    }

    public void LoadWords(GameObject myObj)
    {
        GameObject currentObject = myObj;
        Transform words = currentObject.transform.Find("Words");

        foreach (Transform child in words.transform)
        {
            GameObject wordSpace = Instantiate(wordPrefab, child.transform.position, Quaternion.identity) as GameObject;
            wordSpace.transform.parent = child;
        }
    }

    void ClearWords(GameObject myObj)
    {
        GameObject currentObject = myObj;

        Transform words = currentObject.transform.Find("Words");

        foreach (Transform child in words.transform)
        {
            if (child.transform.GetChild(0).gameObject.name == "TextTemplate(Clone)")
            {
                Destroy(child.transform.GetChild(0).gameObject);
            }
            else
            {
                print("Nope");
            }


        }
    }
}