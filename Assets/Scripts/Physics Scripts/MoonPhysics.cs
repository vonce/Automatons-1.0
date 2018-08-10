using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonPhysics : MonoBehaviour
{
    public Moon moon;
    public float speed;

    private void Awake()
    {
        moon = GameObject.Find("Moon").GetComponent<Moon>();
    }
    void FixedUpdate ()
    {
        gameObject.GetComponent<Rigidbody>().MovePosition(gameObject.transform.position + transform.forward.normalized * speed / 10);
        if (moon)
        {
            moon.gravity(gameObject.transform);
        }
    }
}
