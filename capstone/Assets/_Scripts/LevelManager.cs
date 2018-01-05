using UnityEngine;
using System.Collections;
using Tobii.Gaming; 

public class LevelManager : MonoBehaviour
{
    public void Update()
    {
        GameObject focusedObject = TobiiAPI.GetFocusedObject();
        if (focusedObject != null)
        {
            print("The user is focused on the " + focusedObject);
        }
        print(focusedObject); 
    }
    public void LoadLevel(string name)
    {
        Debug.Log("New Level load: " + name);
        Application.LoadLevel(name);

    }

    public void QuitRequest()
    {
        Debug.Log("Quit requested");
        Application.Quit();
    }
}
