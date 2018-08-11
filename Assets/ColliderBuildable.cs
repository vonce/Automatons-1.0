using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderBuildable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponentInParent<Status>().colliding = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Collider")
        {
            gameObject.GetComponentInParent<Status>().buildable = false;
            gameObject.GetComponentInParent<Status>().colliding = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Status>() != null)
        {
            gameObject.GetComponentInParent<Status>().buildable = true;
            gameObject.GetComponentInParent<Status>().colliding = false;
        }
    }
}
