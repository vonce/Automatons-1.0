using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    [SerializeField]
    private GameObject automatonPrefab;
    private GameObject automaton;
    [SerializeField]
    private float spawnInterval;
    private float nextSpawn = 0;
    [SerializeField]
    private GameObject front;
    private Status status;

    private void Start()
    {
        status = GetComponent<Status>();
    }

    void Update ()
    {
        if (Time.time >= nextSpawn && status.active == true)
        {
            automaton = Instantiate(automatonPrefab, front.transform.position, Quaternion.identity);
            automaton.tag = gameObject.tag;
            nextSpawn = spawnInterval + Time.time;
        }
    }
}
