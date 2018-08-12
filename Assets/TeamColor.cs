using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamColor : MonoBehaviour {

    private Color col;

    void Start()
    {
        if (transform.parent.tag == "Blue")
        {
            col = Color.blue;
        }
        if (transform.parent.tag == "Red")
        {
            col = Color.red;
        }
        if (transform.parent.tag == "Green")
        {
            col = Color.green;
        }
        gameObject.GetComponent<MeshRenderer>().material.color = col;
    }
}
