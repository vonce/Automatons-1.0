using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Physics : MonoBehaviour
{
    public Moon moon;
    public float speed;
        
    void FixedUpdate ()
    {
        gameObject.GetComponent<Rigidbody>().MovePosition(gameObject.transform.position + transform.forward.normalized * speed / 10);
        if (moon)
        {
            moon.gravity(gameObject.transform);
        }
    }
}
