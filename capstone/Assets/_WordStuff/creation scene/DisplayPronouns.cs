using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPronouns : MonoBehaviour {
    public GameObject loadWordsHere;
    public GameObject wordPrefab; 
    string[,] pronouns = {{"I", "me", "my", "mine", "I'm"},
        { "we", "we're", "us", "our", "ours"},
        { "they", "they're", "they", "their", "theirs"},
        { "it", "it's", "it", "its", "its"},
        { "he", "he's", "his", "him", "him" },
        { "she", "she's", "hers", "her", "her"}};

    string[] articles = { "a", "an", "the", "this", "these", "those" };


    string[,] verbs = {{ "was", "go", "want", "think", "feel", "look", "wonder" },
                        { "were", "go", "want", "think", "feel", "look", "wonder"},
                        { "was", "goes", "wants", "thinks", "feels", "looks", "wonders"}};


	// Use this for initialization
	void Start () {
        int randomOne = Random.Range(0, pronouns.Length);
        int randomTwo = Random.Range(0, verbs.Length);

        string[] pronoun = { pronouns[randomOne, 0], pronouns[randomOne, 1], pronouns[randomOne, 2],
                            pronouns[randomOne, 3], pronouns[randomOne, 4] } ;
        string[] verb = { verbs[randomTwo, 0], verbs[randomTwo, 1],
            verbs[randomTwo, 2], verbs[randomTwo, 3], verbs[randomTwo, 4] };

        LoadWords(pronoun, "Pronouns");
        LoadWords(verb, "Verbs");
		
	}


    void LoadWords(string[] words, string gameObject)
    {
        Transform gettingLoadObject = loadWordsHere.transform.Find(gameObject);

        int i = 0;
        foreach (Transform child in gettingLoadObject.transform)
        {
            Text toFill = wordPrefab.GetComponent<Text>();
            toFill.text = words[i];

            GameObject wordSpace = Instantiate(wordPrefab, child.transform.position, Quaternion.identity) as GameObject;
            wordSpace.transform.parent = child;

            print("Word prefab is " + wordPrefab);

        }
        
    
    }
}
