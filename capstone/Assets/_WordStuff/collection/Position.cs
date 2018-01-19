using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour {

    // Use this for initialization
    private void OnDrawGizmos()
    {
        //Gizmos.DrawWireCube(transform.position, new Vector3 (1, 1, 1));
        Gizmos.DrawWireSphere(transform.position, 1);
    }

}
