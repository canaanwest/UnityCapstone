using UnityEngine;
using System.Collections;
using System.Diagnostics;
using System.Threading;
using Tobii.Gaming; 

public class LevelManager : MonoBehaviour
{
    public GameObject creationButton;
    public GameObject galleryButton;
    public GameObject quitButton;
    public GameObject collectionScene;

    public void Update()
    {
        GameObject focusedObject = TobiiAPI.GetFocusedObject();
        // EyeSelectLevel(focusedObject);   
       // GetTimeElapsed(focusedObject);
    }

    public void LoadLevel(string name)
    {
        print ("New Level load: " + name);
        Application.LoadLevel(name);

    }

    public void QuitRequest()
    {
        print ("Quit requested");
        Application.Quit();
    }

    public void EyeSelectLevel(GameObject focusedObject)
    {

        if (focusedObject == creationButton)
        {
            print(creationButton);
            focusedObject = null;
            LoadLevel("Creation");
        }
        else if (focusedObject == galleryButton)
        {
            //LoadLevel("Gallery");
        }
        else if (focusedObject == quitButton)
        {
            // LoadLevel("Home");
        }
    }

    public void GetTimeElapsed(GameObject focusedObject)
    {
        GameObject currentFocusedObj = TobiiAPI.GetFocusedObject();
        if (focusedObject != null)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

           // while (currentFocusedObj == focusedObject)
            //{
                long elapsedTime = stopwatch.ElapsedTicks;
                for (int i = 0; i < 1000; i++) 
                {
                    print("i is" + i);
                    print ("Elapsed time is " + elapsedTime);
                }
                currentFocusedObj = TobiiAPI.GetFocusedObject();
                //LoadLevel("Gallery");
            //}
            stopwatch.Stop(); 


            print("The user is focused on the " + focusedObject);

        }
    }

}
