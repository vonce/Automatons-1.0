using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Allied : MonoBehaviour, IObject
{
    private HashSet<GameObject> alliedSet;
    private HashSet<GameObject> tempSet;

    public ObjectE enumID()
    {
        return ObjectE.Allied;
    }
    public GameObject Object(HashSet<GameObject> set, int option)
    {
        alliedSet = new HashSet<GameObject>();
        foreach (GameObject obj in set)
        {
            if (obj != null && obj.tag == gameObject.tag)
            {
                alliedSet.Add(obj);
            }
        }

        if (option == (int)ObjectOptionE.Nearest)
        {

        }
        if (option == (int)ObjectOptionE.Farthest)
        {
            GameObject farthest = null;
            float distance = 0;
            foreach (GameObject obj in alliedSet)
            {
                if (obj != null)
                {
                    Vector3 difference = obj.transform.position - transform.position;
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
            return GetComponent<Status>().allyBase;
        }
        if (option == (int)ObjectOptionE.Factory)
        {
            tempSet = new HashSet<GameObject>(alliedSet);
            foreach (GameObject obj in tempSet)
            {
                if (obj != null && obj.GetComponent<Status>().unitType != UnitTypeE.Factory)
                {
                    alliedSet.Remove(obj);
                }
            }
        }
        if (option == (int)ObjectOptionE.Refinery)
        {
            tempSet = new HashSet<GameObject>(alliedSet);
            foreach (GameObject obj in tempSet)
            {
                if (obj != null && obj.GetComponent<Status>().unitType != UnitTypeE.Refinery)
                {
                    alliedSet.Remove(obj);
                }
            }
        }
        if (option == (int)ObjectOptionE.Emitter)
        {
            tempSet = new HashSet<GameObject>(alliedSet);
            foreach (GameObject obj in tempSet)
            {
                if (obj != null && obj.GetComponent<Status>().unitType != UnitTypeE.Emitter)
                {
                    alliedSet.Remove(obj);
                }
            }
        }
        if (option == (int)ObjectOptionE.Turret)
        {
            tempSet = new HashSet<GameObject>(alliedSet);
            foreach (GameObject obj in tempSet)
            {
                if (obj != null && obj.GetComponent<Status>().unitType != UnitTypeE.Turret)
                {
                    alliedSet.Remove(obj);
                }
            }
        }
        if (option == (int)ObjectOptionE.Automaton)
        {
            tempSet = new HashSet<GameObject>(alliedSet);
            foreach (GameObject obj in tempSet)
            {
                if (obj != null && obj.GetComponent<Status>().unitType != UnitTypeE.Automaton)
                {
                    alliedSet.Remove(obj);
                }
            }
        }
        GameObject closest = new GameObject();
        
        float dist = Mathf.Infinity;
        foreach (GameObject obj in alliedSet)
        {
            if (obj != null)
            {
                Vector3 difference = obj.transform.position - transform.position;
                float currentDistance = difference.magnitude;
                if (currentDistance < dist)
                {
                    dist = currentDistance;
                    closest = obj;
                }
            }
        }
        return closest;
    }
}
