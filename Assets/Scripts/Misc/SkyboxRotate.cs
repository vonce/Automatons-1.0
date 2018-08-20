using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxRotate : MonoBehaviour
{
	    void FixedUpdate ()
    {
            RenderSettings.skybox.SetFloat("_Rotation", Time.time);// rotates skybox around for illusion of rotatation
    }
}
