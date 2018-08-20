using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphericalCoordinates : MonoBehaviour
{
    private Spherical sphericalCoordinates;//coordinates in spherical coordinates
    private Vector3 cartesianCoordinates;//coordinates in cartesian coordinates

    public static void SphericalToCartesian (Spherical spherical, out Vector3 cartesian)//changes spherical to cartesian
    {
        float a = spherical.radius * Mathf.Cos(spherical.phi);
        cartesian = new Vector3(a * Mathf.Cos(spherical.theta), spherical.radius * Mathf.Sin(spherical.phi), a * Mathf.Sin(spherical.theta));
    }

    public static void CartesianToSpherical (Vector3 cartesian, out Spherical spherical)//changes cartesian to spherical
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
        
        sphericalCoordinates.theta += Input.GetAxis("Horizontal") / 50f;//horizontal camera movement
        if (Input.GetKey(KeyCode.UpArrow) == true && sphericalCoordinates.phi < Mathf.PI / 2f)//up camera movement
        {
            if (sphericalCoordinates.phi + 1f / 100f < Mathf.PI / 2f)
            {
                sphericalCoordinates.phi += 1f / 100f;
            }
        }
        if (Input.GetKey(KeyCode.DownArrow) == true && sphericalCoordinates.phi > - Mathf.PI / 2f)//down camera movement
        {
            if (sphericalCoordinates.phi - 1f / 100f > - Mathf.PI / 2f)
            {
                sphericalCoordinates.phi -= 1f / 100f;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f && sphericalCoordinates.radius < 170f)//zoom out camera
        {
            sphericalCoordinates.radius += 5f;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f && sphericalCoordinates.radius > 120f)//zoom in camera
        {
            sphericalCoordinates.radius -= 5f;
        }



        SphericalToCartesian(sphericalCoordinates, out cartesianCoordinates);
        gameObject.transform.position = cartesianCoordinates;
        gameObject.transform.LookAt(new Vector3(0, 0, 0));// orients camera towards center of moon
    }
}
