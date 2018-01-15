using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayCollectedWords : MonoBehaviour
{
    public GameObject wordPrefab;
    public GameObject loadWordsHere;
    public string[] pouchWords;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 10);
    }


    private void Start()
    {
        //this is to identify the script and grab the variable containing collected words.
        // It then does the work of splitting the words. 

        //Next I need to call a function that will do the work of making a 1:1 map to split the words;


        GameObject getCollectedScript = GameObject.Find("PouchWords");
        SaveWord savedWords = getCollectedScript.GetComponent<SaveWord>();
        print("Saved Words: " + savedWords.ReturnCollected());
        pouchWords = savedWords.ReturnCollected().Split(new char[] {});

        foreach (string word in pouchWords)
        {
            print("pouchwords: " + word);
            //attach word to position;
        }

        LoadWords(pouchWords);
    }





    //I'm working here. I want to map a 1:1 ratio of word to position2. 
    public void LoadWords(string[] words)
    {
        //iterate through the words, adding them one-by-one to the positions in
        //the gameObject called "CanvasTL"
        Transform gettingLoadObject = loadWordsHere.transform.Find("Words");

        int count = 0;
        foreach (Transform child in gettingLoadObject.transform)
        {
            count += 1;
        }

        int numberOfIterations = words.Length > count ? words.Length : count;

//        for (int i = 0; i < numberOfIterations; i++)
//        {

//        }

        int i = 0;
        foreach (Transform child in gettingLoadObject.transform)
        {
            if (words.Length >= i)
            {
                GameObject wordSpace = Instantiate(wordPrefab, child.transform.position, Quaternion.identity) as GameObject;
                wordSpace.transform.parent = child;
            }
            i++;
        }
    }
}