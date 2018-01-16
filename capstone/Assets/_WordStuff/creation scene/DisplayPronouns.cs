using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayPronouns : MonoBehaviour {
    string[,] pronouns = {{"I", "me", "my", "mine", "I'm"},
        { "we", "we're", "us", "our", "ours"},
        { "they", "they're", "they", "their", "theirs"},
        { "it", "it's", "it", "its", "its"},
        { "he", "he's", "his", "him", "him" },
        { "she", "she's", "hers", "her", "her"}};

    string[] articles = { "a", "an", "the", "this", "these", "those" };


    string[,] verbs = {{ "was", "go", "want", "think", "want", "feel", "look", "wonder" },
                        { "were", "go", "want", "think", "want", "feel", "look", "wonder"},
                        { "was", "goes", "wants", "thinks", "wants", "feels", "looks", "wonders"}};


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
