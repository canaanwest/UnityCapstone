﻿using System.Collections;
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
        "windchime", "swing", "home", "shake", "fall", "sway", "grow", "blossom", "limb", "reach",
        "hang", "sweep", "chop", "shaded", "quiver", "sleep", "nap", "picnic", "swing", "climb", "climb",
        "crawl", "slept", "napped"  };

    string[] benchWords = new string[] { "bench", "sit", "read", "talk", "chat", "watch", "wooden",
        "think", "benched", "hold", "drink", "water", "seat", "rest", "park", "wood", "ice cream", "eat",
        "picnic", "shade", "write", "view", "reading", "people"};
    string[] lampPostWords = new string[] { "light", "tall", "metal", "old", "dark", "darkness", "creepy",
        "scary", "fire", "lit", "cast", "shadow", "nighttime", "night", "warmth" };



	// Use this for initialization
	void Start () {
        GameObject theScript = GameObject.Find("WordCatcher");
        DisplayWords displayWords = theScript.GetComponent<DisplayWords>();
        currentFocusedObj = displayWords.currentObjectShowingWords;
        decideWhichWord(currentFocusedObj);
    }

    void decideWhichWord(GameObject theFocusedObject)
        //this is deciding which words to send to the text mesh. this is the problem with recycling the texttemplate;

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
