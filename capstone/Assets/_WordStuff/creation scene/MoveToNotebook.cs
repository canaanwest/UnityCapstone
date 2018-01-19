using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tobii.Gaming;
using UnityEngine.EventSystems;

public class MoveToNotebook : MonoBehaviour {
    //public GameObject loadWordsHere;
    public GameObject wordsPrefab;
    private int i;

    Vector3 gazeLocation;
    GraphicRaycaster graphicRaycaster;
    PointerEventData ped;
    PoemBehavior poemBehavior;
    GameObject getPoemBehaviorScript;


    // Use this for initialization

    void Start () {
        getPoemBehaviorScript = GameObject.Find("CanvasR");
        poemBehavior = getPoemBehaviorScript.GetComponent<PoemBehavior>();

        //focusedObject = TobiiAPI.GetFocusedObject();
        TobiiAPI.SubscribeGazePointData();
        StartCoroutine("GetGazePoint");
        i = 0;

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
        graphicRaycaster = GetComponent<GraphicRaycaster>();
        ped = new PointerEventData(null);
        ped.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();
        graphicRaycaster.Raycast(ped, results);
        
        if (results != null) 
        {
            poemBehavior = getPoemBehaviorScript.GetComponent<PoemBehavior>();
         
            foreach (RaycastResult child in results)
            {
                string newWord = child.gameObject.GetComponent<Text>().text;
                poemBehavior.LoadWord(newWord, i);

               
            }

            if (i <= 14)
            {
                i++;
            } else
            {
                i = 0;
            }
            
            print("i is " + i);
            //LoadWord(newWord, i);

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

            poemBehavior.LoadWord(newWord, i);
            i++;
        }
    }

    IEnumerable GetGazePoint()
    {

        while (gazeLocation == null)
        {
            yield return null;
        }


    }


}
