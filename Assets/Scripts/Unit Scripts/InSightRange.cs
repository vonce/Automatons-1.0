using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InSightRange : MonoBehaviour
{
    private float sightRange;
    private Status status;

    void Start()
    {
        status = GetComponentInParent<Status>();
    }

    void Update()
    {
        if (status.inSightRange.Contains(gameObject))
        {
            status.inSightRange.Remove(gameObject);
        }
        if (sightRange != status.sightRange)
        {
            transform.localScale = new Vector3(status.sightRange, status.sightRange);
            sightRange = (status.sightRange);
        }
    }

    void OnTriggerEnter(Collider sight)
    {
        if (sight.gameObject != gameObject.transform.parent && sight.gameObject != gameObject)
        {
            status.inSightRange.Add(sight.gameObject.transform.parent.gameObject);
        }
        SightUpdate();
    }

    void OnTriggerExit(Collider notVisible)
    {
        status.inSightRange.Remove(notVisible.gameObject.transform.parent.gameObject);
        SightUpdate();
    }

    void SightUpdate()
    {
        status.inSightRange.RemoveWhere(GameObject => GameObject == null);
    }
}
