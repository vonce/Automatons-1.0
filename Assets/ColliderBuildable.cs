using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderBuildable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<TriggerBuildable>() != null)
        {
            gameObject.GetComponentInParent<Status>().buildable += 1;
        }
        else if (other.gameObject.GetComponent<ColliderBuildable>() != null)
        {
            gameObject.GetComponentInParent<Status>().colliding += 1;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject != null)
        {
            if (other.gameObject.GetComponent<TriggerBuildable>() != null)
            {
                gameObject.GetComponentInParent<Status>().buildable -= 1;
            }
            else if (other.gameObject.GetComponent<ColliderBuildable>() != null)
            {
                gameObject.GetComponentInParent<Status>().colliding -= 1;
            }
        }
    }
}
