using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreThanSpecial : MonoBehaviour, ICondition
{
    public ConditionE enumID()
    {
        return ConditionE.MoreThanSpecial;
    }
    public bool Condition(GameObject target, int option)
    {
        if (target != null && (float)target.GetComponent<Status>().currentSpecial / (float)target.GetComponent<Status>().maxSpecial > ((float)option / 10f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}