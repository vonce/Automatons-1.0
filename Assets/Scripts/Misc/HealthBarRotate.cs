using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarRotate : MonoBehaviour {

    private GameObject playerCam;

    private void Awake()
    {
        playerCam = GameObject.Find("Player");
    }

    void FixedUpdate()
    {
        transform.rotation = playerCam.transform.rotation;//rotates health bar to player rotation
	}
}
