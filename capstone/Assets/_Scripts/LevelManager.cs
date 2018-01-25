using UnityEngine;
using System.Collections;
using System.Diagnostics;
using System.Threading;
using Tobii.Gaming;

public class LevelManager : MonoBehaviour
{
    GameObject focusedObject;
    public GameObject creation;
    public GameObject collection;
    public GameObject home;

    public void Start()
    {
       // StartCoroutine("NavigateScenes");
    }

    public void Awake()
    {
        StartCoroutine("NavigateScenes");
    }

    public void Update()
    {
        if (TobiiAPI.GetFocusedObject())
        {
            focusedObject = TobiiAPI.GetFocusedObject();
            if (focusedObject == collection)
            {
                ChangeColorOfText();
            }
            
        }


        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 100f) && hit.transform && hit.transform.gameObject.name == "sack_010")
            {
                LoadLevel("Creation");
           
            }

            if(Physics.Raycast(ray, out hit, 100f) && hit.transform && hit.transform.gameObject == collection)
            {
                LoadLevel("Collection");
                print("CLICKKKKKKK");
                ChangeColorOfText();
            }
        }
    }


    public void LoadLevel(string name)
    {
        Application.LoadLevel(name);
    }

    public void QuitRequest()
    {
        Application.Quit();
    }

    void ChangeColorOfText()
    {
        collection.GetComponent<TextMesh>().color = new Color(6/1, 189/1, 249/1, 253/1);
    }

    IEnumerator NavigateScenes()
    {
        print("StartedCoroutine");
        while (focusedObject == null || (focusedObject != collection && focusedObject != creation && focusedObject != home))
        {
            yield return null;
        }

        print("GOT A FOCUSED");
        GameObject navigate = focusedObject;
        
        yield return new WaitForSecondsRealtime(1);

        if(navigate == TobiiAPI.GetFocusedObject())
        {
            yield return new WaitForSecondsRealtime(1);
            if (navigate == TobiiAPI.GetFocusedObject())
            {
                if (navigate == collection)
                {
                    LoadLevel("Collection");
                    focusedObject = null;
                } else if (navigate == creation)
                {
                    LoadLevel("Creation");
                    focusedObject = null;
                } else
                {
                    LoadLevel("Home");
                    focusedObject = null;
                }

                StartCoroutine("NavigateScenes");
            } else
            {
                StartCoroutine("NavigateScenes");
            } 
        } else
        {
            StartCoroutine("NavigateScenes");
        }
    }
}
