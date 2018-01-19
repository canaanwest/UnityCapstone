using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class DisplayCollectedWords : MonoBehaviour
{
    public GameObject wordPrefab;
    public Text text;
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
        pouchWords = savedWords.ReturnCollected().Split(new char[] {});
        pouchWords = pouchWords.Distinct().ToArray();

        foreach (string word in pouchWords)
        {
            //attach word to position;
        }

        LoadWords(pouchWords);
    }





    //I'm working here. I want to map a 1:1 ratio of word to position2. 
    public void LoadWords(string[] words)
    {
        //iterate through the words, adding them one-by-one to the positions in
        //the gameObject called "CanvasTL"

        Transform gettingLoadObject = this.transform.Find("CanvasTL").Find("Words");
        print("Getting load object from display collected words is: " + gettingLoadObject);

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
            if (i < words.Length)
            {
                Text toFill = wordPrefab.GetComponent<Text>();
               
                toFill.text = words[i];
                GameObject wordSpace = Instantiate(wordPrefab, child.transform.position, Quaternion.identity) as GameObject;
                wordSpace.transform.parent = child;

              
               
            }
            i++;
        }
    }
}