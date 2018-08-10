using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderBuildable : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other);
        if (other.gameObject.GetComponent<Status>() != null)
        {
            
            gameObject.GetComponentInParent<Status>().buildable = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Status>() != null)
        {
            gameObject.GetComponentInParent<Status>().buildable = true;
        }
    }
}
