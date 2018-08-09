using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBrain : MonoBehaviour
{
    private Status status;

    private void Awake()
    {
        status = GetComponent<Status>();
    }

    private void Update()
    {
        if (status.logicMatrix != null)
        {
            CheckLogicMatrix();
        }
    }

    private void FixedUpdate()
    {
        if (status.action != null)
        {
            status.action.Action(status.target);
        }
    }

    public void CheckLogicMatrix()
    {
        foreach (LogicGate i in status.logicMatrix)
        {
            if (CheckCondition(i.objectCondition, i.condition) == true)
            {
                if (CheckAction(i.objectAction, i.action) == true)
                {
                    status.action = i.action;
                    break;
                }
            }
        }
    }

    //Checks the OBJECTCONDITION against CONDITION, returns bool
    private bool CheckCondition(IObject[] objectCondition, ICondition condition)
    {
        if (objectCondition != null && condition != null)
        {
            List<GameObject> list = status.inSightRange;
            for (int i = 0; i < objectCondition.Length; i++)
            {
                objectCondition[i].newObjectList(out list);
            }
            if (list[0] != null)
            {
                return condition.Condition(list[0]);
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    //Checks the OBJECTACTION against ACTION, returns bool
    private bool CheckAction(IObject[] objectAction, IAction action)
    {
        if (objectAction != null && action != null)
        {
            List<GameObject> list = status.inSightRange;
            for (int i = 0; i < objectAction.Length; i++)
            {
                objectAction[i].newObjectList(out list);
            }
            if (list[0] != null)
            {
                if (action.ActionCheck(list[0]) == true)
                {
                    status.target = list[0];
                }
                return action.ActionCheck(list[0]);
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}
