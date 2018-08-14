﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    [SerializeField]
    private GameObject automatonPrefab;
    private GameObject automaton;
    [SerializeField]
    private float spawnInterval;
    private float nextSpawn = 0;
    private Status status;
    private Vector3 spawnPoint;

    private void Start()
    {
        status = GetComponent<Status>();
        spawnPoint = gameObject.transform.position + Vector3.ProjectOnPlane(-(transform.position - status.enemyBase.transform.position), transform.up).normalized;
    }

    void Update ()
    {
        if (Time.time >= nextSpawn && status.active == true)
        {
            automaton = Instantiate(automatonPrefab, spawnPoint, Quaternion.LookRotation(-(transform.position - status.enemyBase.transform.position), transform.up));
            automaton.GetComponent<Status>().logicMatrixEnum = status.logicMatrixEnum;
            automaton.tag = gameObject.tag;
            automaton.GetComponent<Status>().enemyBase = status.enemyBase;

            automaton.GetComponent<Status>().primaryType = status.primaryType;
            automaton.GetComponent<Status>().secondaryType = status.secondaryType;
            automaton.GetComponent<Status>().specialType = status.specialType;
            
            nextSpawn = spawnInterval + Time.time;
        }
    }
}
