using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public GameObject explosionPrefab;
    private GameObject explosion;
    private Vector3 startPosition;
    public GameObject target;
    private Vector3 direction;
    private Vector3 targetDirection;
    private Vector3 velocity;
    private float acceleration = 1f;
    [SerializeField]
    private int rocketDamage;
    public int attackPower;

    void Start()
    {
        startPosition = transform.position;
    }

    void OnTriggerEnter(Collider other)//trigger events
    {
        explosion = Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity) as GameObject;
        if (other.gameObject.GetComponentInParent<Status>() != null)
        {
            other.gameObject.GetComponentInParent<Status>().HealthChange(-3);
        }
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        acceleration = 2f + acceleration;
        if (target != null)
        {
            targetDirection = (target.transform.position - transform.position).normalized;
        }
        velocity = velocity + (targetDirection * acceleration * Time.deltaTime);
        transform.position = transform.position + (velocity * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(startPosition - transform.position);

        Destroy(gameObject, 5f);
        startPosition = transform.position;
    }
}
