using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour, IObject
{
    private List<GameObject> tempList;

    public ObjectE enumID()
    {
        return ObjectE.EnemyBase;
    }

    public void filterList(List<GameObject> list)
    {
        list.Clear();
        list.Add(GetComponent<Status>().enemyBase);
    }
}
