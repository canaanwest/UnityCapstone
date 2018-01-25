using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewPoemBehavior : MonoBehaviour
{
    public GameObject wordsPrefab;
    public static GameObject positionIndication;

    // Use this for initialization
    void Start()
    {
        positionIndication = GameObject.Find("IndicatePosition");
    }

    // Update is called once per frame
    void Update()
    {

    }

    //this script is responsible for recieving elements from the pouch and placing them on the Notebook/poemSpace


    public void LoadWord(string word, int i)
    {
        Transform gettingLoadObject = transform.Find("Poem");
        TextMesh toFill = wordsPrefab.GetComponent<TextMesh>();
        toFill.text = word;
        Transform nextPosition;
        Transform position = gettingLoadObject.transform.GetChild(i);
        if (i < 27)
        {
            nextPosition = gettingLoadObject.transform.GetChild(i + 1);
        } else
        {
            nextPosition = gettingLoadObject.transform.GetChild(0);
        }

        DeleteOldWords(position.Find("poemTextTemp(Clone)"));

        GameObject wordSpace = Instantiate(wordsPrefab, position.position, Quaternion.identity) as GameObject;
        positionIndication.transform.position = new Vector3(nextPosition.position.x, nextPosition.position.y-2, nextPosition.position.z);
        wordSpace.transform.parent = position;
    }

    void DeleteOldWords(Transform oldWord)
    {
        if (oldWord)
        {
            print("FOUND!");
            Destroy(oldWord.gameObject);
        }
    }
}
