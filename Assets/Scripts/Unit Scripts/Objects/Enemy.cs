using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IObject
{
    private HashSet<GameObject> enemySet;
    private HashSet<GameObject> tempSet;

    public ObjectE enumID()
    {
        return ObjectE.Enemy;
    }
    public GameObject Object(HashSet<GameObject> set, int option)
    {
        enemySet = new HashSet<GameObject>();
        foreach (GameObject obj in set)
        {
            if (obj != null && obj.tag != gameObject.tag)
            {
                enemySet.Add(obj);
            }
        }
        
        if (option == (int)ObjectOptionE.Nearest)
        {
            
        }
        if (option == (int)ObjectOptionE.Farthest)
        {
            GameObject farthest = null;
            float distance = 0;
            foreach (GameObject obj in enemySet)
            {
                if (obj != null)
                {
                    Vector3 difference = obj.transform.position = transform.position;
                    float currentDistance = difference.magnitude;
                    if (currentDistance > distance)
                    {
                        distance = currentDistance;
                        farthest = obj;
                    }
                }
            }
            return farthest;
        }
        if (option == (int)ObjectOptionE.Base)
        {
            return GetComponent<Status>().enemyBase;
        }
        if (option == (int)ObjectOptionE.Factory)
        {
            tempSet = new HashSet<GameObject>(enemySet);
            foreach (GameObject obj in tempSet)
            {
                if (obj != null && obj.GetComponent<Status>().unitType != UnitTypeE.Factory)
                {
                    enemySet.Remove(obj);
                }
            }
        }
        if (option == (int)ObjectOptionE.Refinery)
        {
            tempSet = new HashSet<GameObject>(enemySet);
            foreach (GameObject obj in tempSet)
            {
                if (obj != null && obj.GetComponent<Status>().unitType != UnitTypeE.Refinery)
                {
                    enemySet.Remove(obj);
                }
            }
        }
        if (option == (int)ObjectOptionE.Emitter)
        {
            tempSet = new HashSet<GameObject>(enemySet);
            foreach (GameObject obj in tempSet)
            {
                if (obj != null && obj.GetComponent<Status>().unitType != UnitTypeE.Emitter)
                {
                    enemySet.Remove(obj);
                }
            }
        }
        if (option == (int)ObjectOptionE.Turret)
        {
            tempSet = new HashSet<GameObject>(enemySet);
            foreach (GameObject obj in tempSet)
            {
                if (obj != null && obj.GetComponent<Status>().unitType != UnitTypeE.Turret)
                {
                    enemySet.Remove(obj);
                }
            }
        }
        if (option == (int)ObjectOptionE.Automaton)
        {
            tempSet = new HashSet<GameObject>(enemySet);
            foreach (GameObject obj in tempSet)
            {
                if (obj != null && obj.GetComponent<Status>().unitType != UnitTypeE.Automaton)
                {
                    enemySet.Remove(obj);
                }
            }
        }
        GameObject nearest = null;
        float dist = Mathf.Infinity;
        foreach (GameObject obj in enemySet)
        {
            if (obj != null)
            {
                Vector3 difference = obj.transform.position = transform.position;
                float currentDistance = difference.magnitude;
                if (currentDistance < dist)
                {
                    dist = currentDistance;
                    nearest = obj;
                }
            }
        }
        return nearest;
    }
}
