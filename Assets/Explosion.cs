using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<Status>() != null)
        {
            other.gameObject.GetComponentInParent<Status>().HealthChange(-2);
        }
    }

    // Update is called once per frame
    void Update ()
    {
        Destroy(gameObject, .1f);
    }
}
