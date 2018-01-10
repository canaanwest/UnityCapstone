using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour {
    public GameObject wordPrefab;
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 100f))
                {
                    if (hit.transform)
                    {
                        print("This is hit: " + hit);
                        LoadWords(hit.transform.gameObject);
                    }
                }
            }
        }
            // if (Object is being focused on) {
            //execute a piece of code that fills that object's children with words
       //}
	}

    public void LoadWords (GameObject myObj)
    {

        GameObject currentObject = myObj;
        //GameObject[] words = currentObject.Find(GameObject.FindObjectOfType<Words>());
        Transform words = currentObject.transform.GetChild(0);

        print(words);
       

        foreach (Transform child in words.transform)
        {
            print("this is" + this);
            GameObject wordSpace = Instantiate(wordPrefab, child.transform.position, Quaternion.identity) as GameObject;
            wordSpace.transform.parent = child;

        }
    }
}
