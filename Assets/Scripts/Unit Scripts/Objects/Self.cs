using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Self : MonoBehaviour, IObject
{
    public ObjectE enumID()
    {
        return ObjectE.Self;
    }
    public GameObject Object(HashSet<GameObject> set, int option)
    {
        return gameObject;
    }

}
