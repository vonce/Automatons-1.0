using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBuildable : MonoBehaviour {

    private Color col;

    private void Awake()
    {
        if (transform.parent.tag == "Blue")
        {
            col = Color.blue;
        }
        if (transform.parent.tag == "Red")
        {
            col= Color.red;
        }
        if (transform.parent.tag == "Green")
        {
            col= Color.green;
        }
        col.a = .15f;

        gameObject.GetComponent<MeshRenderer>().material.color = col;
    }
}
