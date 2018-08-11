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
        foreach (GameObject i in list)
        {
            if (i != null && i.transform.position.magnitude < list[0].transform.position.magnitude)
            {
                list[0] = i;
            }
        }
        if (list.Count >= 1)
        {
            list.RemoveRange(1, list.Count - 1);
        }
    }
}
