using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamColor : MonoBehaviour {

    private Color col;

    void Start()
    {
        if (transform.transform.parent != null)
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
        }
        else
        {
            if (gameObject.tag == "Blue")
            {
                col = Color.blue;
            }
            if (gameObject.tag == "Red")
            {
                col = Color.red;
            }
            if (gameObject.tag == "Green")
            {
                col = Color.green;
            }
        }
        gameObject.GetComponent<MeshRenderer>().material.color = col;
    }
}
