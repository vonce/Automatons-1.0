using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Always : MonoBehaviour, ICondition
{
    public ConditionE enumID()
    {
        return ConditionE.Always;
    }
    public bool Condition(GameObject target)
    {
        return true;
    }
    public bool Condition(GameObject target, int subOption)
    {
        return true;
    }
}