using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoemBehavior : MonoBehaviour {
    public GameObject wordsPrefab;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //this script is responsible for recieving elements from the pouch and placing them on the Notebook/poemSpace


    public void LoadWord(string word, int i)
    {
        Transform gettingLoadObject = transform.Find("Poem");
     
        Text toFill = wordsPrefab.GetComponent<Text>();
     
        Transform position = gettingLoadObject.transform.GetChild(i);
        toFill.text = word;
        GameObject wordSpace = Instantiate(wordsPrefab, position.position, Quaternion.identity) as GameObject;

        wordSpace.transform.parent = position;
    }

}
