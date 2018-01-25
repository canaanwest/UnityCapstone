using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

public class CameraControl : MonoBehaviour
{
    public float speed = 5f;
    public float rotationTransform;
    public GameObject focusedObject;
    public static GameObject rightArrow;
    public static GameObject leftArrow;

    // Use this for initialization
    void Start()
    {
        StartCoroutine("EyeNavigation");
    }

    // Update is called once per frame
    public void Update()
    {
        if (TobiiAPI.GetFocusedObject() != null)
        {
            focusedObject = TobiiAPI.GetFocusedObject();
        }

        print("FOCUSED OBJECT IS " + focusedObject); 
        KeyboardMoveLeft();
        KeyboardMoveRight();
    }

    void KeyboardMoveLeft()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rotationTransform -= 1;
            transform.rotation = Quaternion.Euler(0, rotationTransform, 0);
        }
    }

    void KeyboardMoveRight()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rotationTransform += 1;
            transform.rotation = Quaternion.Euler(0, rotationTransform, 0);
        }
    }

    void EyeMoveLeft()
    {
        rotationTransform -= 1;
        transform.rotation = Quaternion.Euler(0, rotationTransform, 0);
    }

    void EyeMoveRight()
    {
        rotationTransform += 1;
        transform.rotation = Quaternion.Euler(0, rotationTransform, 0);
        
    }

    IEnumerator EyeNavigation()
    {
        print("Starting coroutine Eye Nav");
        while (focusedObject == null || (focusedObject.name != "NavRight" && focusedObject.name != "NavLeft"))
        {
            yield return null;
        }

        print("Focused on LEFT OR RIGHT ARROW!!");
        GameObject directionArrow;
        directionArrow = focusedObject;

        yield return new WaitForSecondsRealtime(.5f);
        if (directionArrow == focusedObject)
        {
            print("made it past a second");
            yield return new WaitForSecondsRealtime(.5f);
            if (directionArrow == focusedObject)
            {
                if (directionArrow.name == "NavLeft")
                {
                    EyeMoveLeft();
                    yield return new WaitForSecondsRealtime(.01f);
                    EyeMoveLeft();

                    yield return new WaitForSecondsRealtime(.01f);
                    EyeMoveLeft();

                    yield return new WaitForSecondsRealtime(.01f);
                    EyeMoveLeft();

                    yield return new WaitForSecondsRealtime(.01f);
                    EyeMoveLeft();

                    yield return new WaitForSecondsRealtime(.01f);
                    EyeMoveLeft();
                    yield return new WaitForSecondsRealtime(.01f);
                    EyeMoveLeft();
                    yield return new WaitForSecondsRealtime(.01f);
                    EyeMoveLeft();
                    yield return new WaitForSecondsRealtime(.01f);
                    EyeMoveLeft();
                    yield return new WaitForSecondsRealtime(.01f);
                    EyeMoveLeft();
                    yield return new WaitForSecondsRealtime(.01f);
                    EyeMoveLeft();

                } else
                {
                    EyeMoveRight();
                    yield return new WaitForSecondsRealtime(.01f);
                    EyeMoveRight();
                    yield return new WaitForSecondsRealtime(.01f);
                    EyeMoveRight();
                    yield return new WaitForSecondsRealtime(.01f);
                    EyeMoveRight();
                    yield return new WaitForSecondsRealtime(.01f);
                    EyeMoveRight();
                    yield return new WaitForSecondsRealtime(.01f);
                    EyeMoveRight();
                    yield return new WaitForSecondsRealtime(.01f);
                    EyeMoveRight();
                    yield return new WaitForSecondsRealtime(.01f);
                    EyeMoveRight();
                    yield return new WaitForSecondsRealtime(.01f);
                    EyeMoveRight();
                    yield return new WaitForSecondsRealtime(.01f);
                    EyeMoveRight();
                    yield return new WaitForSecondsRealtime(.01f);
                    EyeMoveRight();


                }
                focusedObject = null;
                yield return new WaitForSecondsRealtime(.2f);
                StartCoroutine("EyeNavigation");
            } else
            {
                StartCoroutine("EyeNavigation");
            }
        } else
        {
            StartCoroutine("EyeNavigation");
        }
    }

}
