using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tobii.Gaming;
using UnityEngine.EventSystems;

public class MoveToNotebook : MonoBehaviour {
    //public GameObject loadWordsHere;
    public GameObject wordsPrefab;
    int i = 0;
    //GazePoint gazeLocation;
    Vector3 gazeLocation;
    Object focusedObject;
    GraphicRaycaster graphicRaycaster;
    
    PointerEventData ped = new PointerEventData(null);
    // Use this for initialization

    void Start () {
        //graphicRaycaster = GetComponent<GraphicRaycaster>();
        //focusedObject = TobiiAPI.GetFocusedObject();

        TobiiAPI.SubscribeGazePointData();
        //StartCoroutine("GetGazePoint");
    }

    // Update is called once per frame
    void Update () {
        //gazeLocation = TobiiAPI.GetGazePoint().Screen;

        if (Input.GetMouseButtonDown(0))
        {
            SelectWordForMovement();
        }	
	}

    void SelectWordForMovement()
    {

        //Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(Input.mousePosition, new Vector2(0, 0));

        if (hit.collider)
        {
            string newWord = hit.collider.transform.GetComponent<Text>().text;

            LoadWord(newWord, i);
            i++;
        }
    }

    void EyeSelectWordForMovement()
    {
        //what I should do here is create a hit and if the hit has a collider, THEN check 2 seconds later to see 
        //if I'm within a certain number of pixels of that same object;
        //
        //Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       RaycastHit2D hit = Physics2D.Raycast(new Vector3(gazeLocation.x+10f, gazeLocation.y+10), new Vector2(0, 0));

        if (hit.collider)
        {
            StartCoroutine("GetGazePoint");
            string newWord = hit.collider.transform.GetComponent<Text>().text;
            //print(instanceID);

            LoadWord(newWord, i);
            i++;
        }
    }

    void LoadWord(string word, int i)
    {
        print("This.transform.parent: ");
        print(this.transform.parent.parent.parent.parent);
        Transform gettingLoadObject = this.transform.parent.parent.parent.parent.transform.Find("CanvasR").Find("Poem");
        print("gettingLoadObject is " + gettingLoadObject);

        Text toFill = wordsPrefab.GetComponent<Text>();
        print("gettingLoadObject is " + gettingLoadObject);

        Transform position = gettingLoadObject.transform.GetChild(i);
        toFill.text = word;
        GameObject wordSpace = Instantiate(wordsPrefab, position.position, Quaternion.identity) as GameObject;
        wordSpace.transform.parent = position;
    }
}
