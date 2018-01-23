using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewDisplayPronouns : MonoBehaviour
{
    public GameObject loadWordsHere;
    public GameObject wordPrefab;

    string[,] pronouns = {{"I", "me", "my", "mine", "I'm"},
        { "we", "we're", "us", "our", "ours"},
        { "they", "they're", "they", "their", "theirs"},
        { "it", "it's", "it", "its", "its"},
        { "he", "he's", "his", "him", "him" },
        { "she", "she's", "hers", "her", "her"},
        { "a", "an", "the", "this", "these" }};


    string[,] verbs = {{ "was", "go", "want", "think", "feel", "look", "wonder" },
                        { "were", "go", "want", "think", "feel", "look", "wonder"},
                        { "was", "goes", "wants", "thinks", "feels", "looks", "wonders"},
                        { "were", "goes", "want", "think", "feels", "look", "wonders"} };


    // Use this for initialization
    void Start()
    {
        int randomOne = Random.Range(0, 7);
        int randomTwo;

        // need a switch statement to decide what "random2" should be
        if (randomOne == 1) { randomTwo = 0; }
        else if (randomOne <= 2) { randomTwo = 1; }
        else if (randomOne == 6) { randomTwo = 3; }
        else { randomTwo = 2; }




        string[] pronoun = { pronouns[randomOne, 0], pronouns[randomOne, 1], pronouns[randomOne, 2],
                            pronouns[randomOne, 3], pronouns[randomOne, 4] };

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
            TextMesh toFill = wordPrefab.GetComponent<TextMesh>();
            toFill.text = words[i];

            GameObject wordSpace = Instantiate(wordPrefab, child.transform.position, Quaternion.identity) as GameObject;
            wordSpace.transform.parent = child;


            i++;
        }

    }
}
