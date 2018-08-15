using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour, IAction
{
    private UnitBrain unitBrain;
    private Vector3 moveDirection;

    public ActionE enumID()
    {
        return ActionE.Move;
    }
    void Start()
    {
        unitBrain = GetComponent<UnitBrain>();
    }

    public bool ActionCheck(GameObject target, int option)
    {
        if (target != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Action(GameObject target, int option)
    {
        unitBrain.MoveToTarget();
    }
}
