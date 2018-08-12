using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public GameObject parentUnit;
    private Color col;

    void OnTriggerEnter(Collider other)//trigger events
    {
        if (other.gameObject.GetComponentInParent<Status>() != null && parentUnit != null)
        {
            other.gameObject.GetComponentInParent<Status>().HealthChange(-(parentUnit.GetComponent<Status>().attackPower + 2));
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
        Destroy(gameObject, 4f);
    }
}
