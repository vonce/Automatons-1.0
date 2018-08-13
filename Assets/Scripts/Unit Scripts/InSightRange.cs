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
        //status.inSightRange.Add(status.enemyBase);
    }

    void Update()
    {
        if (sightRange != status.sightRange)
        {
            transform.localScale = new Vector2(status.sightRange, status.sightRange);
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
        status.inSightRange.RemoveAll(GameObject => GameObject == null);
    }
}
