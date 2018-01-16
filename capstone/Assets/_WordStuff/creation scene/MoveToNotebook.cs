using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveToNotebook : MonoBehaviour {
    public BoxCollider2D collider;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButtonDown(0))
        {
            SelectWordForMovement();
        }	
	}

    void SelectWordForMovement()
    {
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        print("worldpoint is : " + worldPoint);
        RaycastHit2D hit = Physics2D.Raycast(Input.mousePosition, new Vector2(0, 0));

        
        print("hit is " + hit);
        if (hit.collider)
        {
            print("You hit a word!");
            print(hit.collider.transform.GetComponent<Text>().text);
        }
    }


}
