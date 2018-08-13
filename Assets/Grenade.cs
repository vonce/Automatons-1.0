using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {

    [SerializeField]
    private GameObject explosionPrefab;
    private GameObject explosion;

    void OnTriggerEnter(Collider other)//trigger events
    {
        explosion = Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 4f);
    }
}
