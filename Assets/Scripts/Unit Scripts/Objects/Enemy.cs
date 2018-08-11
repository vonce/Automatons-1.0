using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IObject
{
    private List<GameObject> tempList;
    public ObjectE enumID()
    {
        return ObjectE.Enemy;
    }

    public void filterList(List<GameObject> list)
    {
        tempList = new List<GameObject>(list);
        foreach (GameObject i in tempList)
        {
            if (i != null && i.tag == gameObject.tag)
            {
                list.Remove(i);
            }
        }
    }
}
