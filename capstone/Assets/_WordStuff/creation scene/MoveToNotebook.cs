using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveToNotebook : MonoBehaviour {
   // public GameObject loadWordsHere;
    public GameObject wordsPrefab;
    int i = 0;
	// Use this for initialization
	void Start () {
        print(wordsPrefab);
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButtonDown(0))
        {
            SelectWordForMovement();
        }	
	}

    void SelectWordForMovement()
    {
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(Input.mousePosition, new Vector2(0, 0));

        if (hit.collider)
        {
            string newWord = hit.collider.transform.GetComponent<Text>().text;
            int instanceID= hit.collider.GetInstanceID();
            //print(instanceID);

            LoadWord(newWord, i);
            i++;
        }
    }

    void LoadWord(string word, int i)
    {
        Transform gettingLoadObject = this.transform.Find("Poem");
        Text toFill = wordsPrefab.GetComponent<Text>();
        print("gettingLoadObject is " + gettingLoadObject);

        Transform position = gettingLoadObject.transform.GetChild(i);

        //foreach (Transform child in gettingLoadObject.transform)
        //{
           // print("the game object in child.transform is " + child.transform.Find("justText(Clone)"));
            //if (child.transform.gameObject)
            //{
                toFill.text = word;
                GameObject wordSpace = Instantiate(wordsPrefab, position.position, Quaternion.identity) as GameObject;
                wordSpace.transform.parent = position;
         //   }
        //}
    }


}
