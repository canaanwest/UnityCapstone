using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateWord : MonoBehaviour {
    TextMesh toFill;
    public GameObject currentFocusedObj;

    string[] tree = new string[]{"tree", "climb", "breeze", "dance", "leaf", "leaves",
        "bark", "green", "brown", "wind",  "branch", "branches", "roots", "rooted", "caterpiller",
        "ladybug", "ants", "seeds", "flowers", "birds", "nests", "bird", "nest", "eggs", "sticks",
        "monkeys", "monkey", "flower", "flowers", "fort", "base", "shade", "fruit", "oranges", "apples",
        "windchime", "swing", "home", "shake", "fall", "sway", "grow", "blossom", "limb", "reach",
        "hang", "sweep", "chop", "shaded", "quiver", "sleep", "nap", "picnic", "swing", "climb", "climb",
        "crawl", "slept", "napped"  };

    string[] bench = new string[] { "bench", "sit", "read", "talk", "chat", "watch", "wooden",
        "think", "benched", "hold", "drink", "water", "seat", "rest", "park", "wood", "ice cream", "eat",
        "picnic", "shade", "write", "view", "reading", "people"};
    string[] lampPost = new string[] { "light", "tall", "metal", "old", "dark", "darkness", "creepy",
        "scary", "fire", "lit", "cast", "shadow", "nighttime", "night", "warmth" };
    string[] duck = new string[] { "quack", "waddle", "swim", "attack", "run", "bark", "white", "colorful",
        "mallard", "farm", "bread", "crumbs", "dirty", "water" };
    string[] picnic = new string[] { "picnic", "basket", "fruit", "chips", "sandwich", "bread", "watermelon",
        "bananas", "sleep", "nap", "play", "toss", "family", "friends", "kids", "people", "folks", "blanket",
        "grass", "sunshine", "ball", "frisbee"};
    string[] fountain = new string[] {"water", "splash", "play", "watch", "water", "flow", "squirt", "wet",
        "shoot", "stream", "fall", "mist", "round", "stone" };
    string[] cloud = new string[] {"cloud", "float", "marshmallow", "painted", "puffy", "white", "grey",
        "rain", "shade", "sun", "block",  "shapes", "imagine", "imagination" } ;
    string[] bird = new string[] {"fly", "chirp", "sing", "colorful", "red", "blue", "black", "soar",
        "high", "ground", "squawk", "bluejay", "robin", "hawk", "nest", "egg", "perch", "trees",};
    string[] sidewalk = new string[] {"ride", "run", "walk", "path", "stroll", "coast", "bike",
        "skate", "chase", "skip", "walking path", "exercise", "ground", "hopscotch" };
    string[] rock = new string[] {"climb", "hide", "shadow", "old", "ancient", "shade",
        "protect", "crumble", "slide", "explore", "shape", "size", "huge", "tiny", "hard",
        "fun", "grey", "red", "mountains", "hills", "explorer", "tall"};
    string[] bike = new string[] {"bike", "store", "ride", "lock", "helmet", "kneepads", "fun",
        "fast", "wheels", "handlebars", "pedal", "spoke", "gear" };




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
        print("IN GENERATE: CURRENT FOCUSED WORD " + theFocusedObject);
        string[] currentWordCollection;
        toFill = GetComponent<TextMesh>();

        if (currentFocusedObj.name == "Bench") { currentWordCollection = bench; }
        else if (currentFocusedObj.name == "Tree") { currentWordCollection = tree; }
        else if (currentFocusedObj.name == "LampPost") { currentWordCollection = lampPost; }
        else if (currentFocusedObj.name == "Cloud") { currentWordCollection = cloud; }
        else if (currentFocusedObj.name == "Sidewalk") { currentWordCollection = sidewalk; }
        else if (currentFocusedObj.name == "blueJay") { currentWordCollection = bird; }
        else if (currentFocusedObj.name == "LandDuck") { currentWordCollection = duck; }
        else if (currentFocusedObj.name == "Rock") { currentWordCollection = rock; }
        else if (currentFocusedObj.name == "Fountain") { currentWordCollection = fountain; }
        else if (currentFocusedObj.name == "Blanket") { currentWordCollection = picnic; }
        else if (currentFocusedObj.name == "Bike") { currentWordCollection = bike; }




        else { currentWordCollection = new string[] { "Sorry", "there's", "an", "error" }; }

        toFill.text = currentWordCollection[Random.Range(0, currentWordCollection.Length)];
    }
}
