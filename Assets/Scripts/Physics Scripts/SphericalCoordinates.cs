using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphericalCoordinates : MonoBehaviour
{
    private Spherical sphericalCoordinates;
    private Vector3 cartesianCoordinates;

    public static void SphericalToCartesian (Spherical spherical, out Vector3 cartesian)
    {
        float a = spherical.radius * Mathf.Cos(spherical.phi);
        cartesian = new Vector3(a * Mathf.Cos(spherical.theta), spherical.radius * Mathf.Sin(spherical.phi), a * Mathf.Sin(spherical.theta));
    }

    public static void CartesianToSpherical (Vector3 cartesian, out Spherical spherical)
    {
        if (cartesian.x == 0)
        {
            cartesian.x = Mathf.Epsilon;
        }
        spherical.radius = Mathf.Sqrt(cartesian.x * cartesian.x + cartesian.y * cartesian.y + cartesian.z * cartesian.z);
        spherical.theta = Mathf.Atan(cartesian.z / cartesian.x);
        if (cartesian.x < 0)
        {
            spherical.theta += Mathf.PI;
        }
        spherical.phi = Mathf.Asin(cartesian.y / spherical.radius);
    }

    void Start()
    {
        CartesianToSpherical(gameObject.transform.position, out sphericalCoordinates);
    }

    void FixedUpdate()
    {
        
        sphericalCoordinates.theta += Input.GetAxis("Horizontal") / 50f;
        if (Input.GetKey(KeyCode.UpArrow) == true && sphericalCoordinates.phi < Mathf.PI / 2.25)
        {
            sphericalCoordinates.phi += 1f / 50f;
        }
        if  (Input.GetKey(KeyCode.DownArrow) == true && sphericalCoordinates.phi > -Mathf.PI / 2.25)
        {
            sphericalCoordinates.phi += -1f / 50f;
        }

        

        SphericalToCartesian(sphericalCoordinates, out cartesianCoordinates);
        gameObject.transform.position = cartesianCoordinates;
        gameObject.transform.LookAt(new Vector3(0, 0, 0));
    }
}
