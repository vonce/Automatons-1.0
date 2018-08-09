using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Physics : MonoBehaviour
{
    public Moon moon;
	// Update is called once per frame
	void FixedUpdate ()
    {
        
        if (moon)
        {
            moon.gravity(gameObject.transform);
        }
        gameObject.GetComponent<Rigidbody>().MovePosition(gameObject.transform.position + transform.right.normalized / 10);

    }
}
