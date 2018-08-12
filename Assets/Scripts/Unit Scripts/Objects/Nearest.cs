using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nearest : MonoBehaviour, IObject
{
    public ObjectE enumID()
    {
        return ObjectE.Nearest;
    }
    public void filterList(List<GameObject> list)
    {
        foreach (GameObject obj in list)
        {
            if (obj != null && Vector3.Distance(gameObject.transform.position, obj.transform.position) < Vector3.Distance(gameObject.transform.position, list[0].transform.position))
            {
                list[0] = obj;
            }
        }
        if (list.Count >= 1)
        {
            list.RemoveRange(1, list.Count - 1);
        }
    }
}
