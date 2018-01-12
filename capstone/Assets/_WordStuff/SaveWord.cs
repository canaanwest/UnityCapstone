using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveWord : MonoBehaviour {

    static string collectedWords = "";
    TextMesh getWord;
    //where should I put them?

    //maybe I can use a global variable, which would have to be something that oculd be 
    //dynamically changed, like a hash table maybe?
    //
    //on click
    //if clicked object has tag/name TextTemplate
    // string collectedWords += object.getelement<text>
    // 
    
    void emitEventForCollectObjectWords()
        //right now, this automatically gets all of the objects.
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100f) && hit.transform && hit.transform.gameObject.name == "TextTemplate(Clone)")
        {
            print("YOU HIT A WORD");
           // print(hit.transform.gameObject);
            getWord = GetComponent<TextMesh>();
            string word = getWord.text;
            collectedWords += word + " ";
            Destroy(getWord);
            print(collectedWords);
        }
    }

    private void OnMouseDown()
    {
        emitEventForCollectObjectWords();
    }

}
