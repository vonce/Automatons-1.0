using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class None : MonoBehaviour, IObject
{
    public ObjectE enumID()
    {
        return ObjectE.None;
    }
    public void filterList(List<GameObject> list)
    {

    }
}
