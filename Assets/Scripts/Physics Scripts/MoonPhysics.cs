﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonPhysics : MonoBehaviour
{
    public Moon moon;

    private void Awake()
    {
        moon = GameObject.Find("Moon").GetComponent<Moon>();
    }
    void FixedUpdate ()
    {
        if (moon)
        {
            moon.gravity(gameObject.transform);
        }
    }
}
