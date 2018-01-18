using UnityEngine;
using System.Collections;
using System.Diagnostics;
using System.Threading;
using Tobii.Gaming;

public class LevelManager : MonoBehaviour
{
    GameObject focusedObject;
    public GameObject creationButton;
    public GameObject galleryButton;
    public GameObject quitButton;
    public GameObject collectionScene;

    public void Start()
    {
        //print("BEFORE THE YEILD");
        //StartCoroutine("WaitAndLoad");
    }

    public void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 100f) && hit.transform && hit.transform.gameObject.name == "sack_010")
            {
                //&& hit.transform.gameObject.name == "sack_010"
                print(hit.transform);
                LoadLevel("Creation");
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
}
