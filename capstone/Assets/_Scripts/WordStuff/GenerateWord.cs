using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateWord : MonoBehaviour {
    TextMesh toFill;
    public GameObject currentFocusedObj;

    string[] treeWords = new string[]{"tree", "climb", "breeze", "dance", "leaf", "leaves",
        "bark", "green", "brown", "wind",  "branch", "branches", "roots", "rooted", "caterpiller",
        "ladybug", "ants", "seeds", "flowers", "birds", "nests", "bird", "nest", "eggs", "sticks",
        "monkeys", "monkey", "flower", "flowers", "fort", "base", "shade", "fruit", "oranges", "apples",
        "windchime", "swing", "home" };

    string[] benchWords = new string[] { "bench", "sit", "read", "talk", "chat", "watch", "wooden",
        "think" };
    string[] lampPostWords = new string[] { "light", "tall", "metal", "old", "dark", "darkness", "creepy", "scary", "fire" };



	// Use this for initialization
	void Start () {
        GameObject theScript = GameObject.Find("WordCatcher");
        DisplayWords displayWords = theScript.GetComponent<DisplayWords>();
        currentFocusedObj = displayWords.currentObjectShowingWords;


        decideWhichWord(currentFocusedObj);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void decideWhichWord(GameObject theFocusedObject)
    {
        string[] currentWordCollection;
        toFill = GetComponent<TextMesh>();

        if (currentFocusedObj.name == "Bench") { currentWordCollection = benchWords; }
        else if (currentFocusedObj.name == "Tree") { currentWordCollection = treeWords; }
        else if (currentFocusedObj.name == "LampPost") { currentWordCollection = lampPostWords; }
        else { currentWordCollection = new string[] { "Sorry", "there's", "an", "error" }; }

        toFill.text = currentWordCollection[Random.Range(0, currentWordCollection.Length)];
    }
}
