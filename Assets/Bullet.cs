using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int attackPower;

    void OnTriggerEnter(Collider other)//trigger events
    {
        if (other.gameObject.GetComponentInParent<Status>() != null)
        {
            other.gameObject.GetComponentInParent<Status>().HealthChange(-(attackPower + 2));
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
        Destroy(gameObject, 2f);
    }
}
