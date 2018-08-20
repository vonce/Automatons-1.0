using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreThanHealth : MonoBehaviour, ICondition
{
    public ConditionE enumID()
    {
        return ConditionE.MoreThanHealth;
    }
    public bool Condition(GameObject target, int option)
    {
        if (target != null && (float)target.GetComponent<Status>().currentHealth / (float)target.GetComponent<Status>().maxHealth > ((float)option / 10f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
