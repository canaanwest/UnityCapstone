using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

public class SaveWord : MonoBehaviour {

    static string collectedWords = "";
    TextMesh getWord;
    GameObject focusedObject;

    private void Start()
    {
        StartCoroutine("SaveWordEyeTrigger");
    }

    private void Update()
    {
        focusedObject = TobiiAPI.GetFocusedObject();
    }

    void ClickEventForCollectObjectWords()
        //right now, this automatically gets all of the objects.
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100f) && hit.transform)
        {
            print("HIT.TRANSFORM = " + hit.transform);
        }
       
        if (Physics.Raycast(ray, out hit, 100f) && hit.transform && hit.transform.gameObject.name == "TextTemplate(Clone)")
        {
            getWord = GetComponent<TextMesh>();
            string word = getWord.text;
            collectedWords += word + " ";
            Destroy(getWord);
        }
    }

    void EyeEventForCollectObjectWords(GameObject selectedWord)
    {
       

        if (selectedWord.name == "TextTemplate(Clone)")
        {
            getWord = selectedWord.GetComponent<TextMesh>();
            string word = getWord.text;
            Destroy(getWord);
            collectedWords += word + " ";
        }
        
    }

    private void OnMouseDown()
    {
        ClickEventForCollectObjectWords();
    }

    public string ReturnCollected()
    {
        return collectedWords;
    }

    IEnumerator SaveWordEyeTrigger()
    {
        while (focusedObject == null || focusedObject.name != "TextTemplate(Clone)")
        {
            yield return null;
        }

        GameObject selectObject;
        selectObject = focusedObject;

        yield return new WaitForSecondsRealtime(1);

        if (selectObject == focusedObject)
        {
            yield return new WaitForSecondsRealtime(1);
            if (selectObject == focusedObject)
            {
                EyeEventForCollectObjectWords(selectObject as GameObject);
                yield return new WaitForSecondsRealtime(2);
                StartCoroutine("SaveWordEyeTrigger");
            } else
            {
                StartCoroutine("SaveWordEyeTrigger");
            }
        }
        else
        {
            StartCoroutine("SaveWordEyeTrigger");
        }
    }

}
