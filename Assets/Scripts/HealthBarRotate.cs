using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarRotate : MonoBehaviour {

    public GameObject playerCam;
    
	// Update is called once per frame
	void Update () {
        transform.rotation = playerCam.transform.rotation;
	}
}
