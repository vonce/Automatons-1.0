using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBrain : MonoBehaviour
{
    private Status status;
    private float nextCheck;
    [SerializeField]
    private float checkRate;
    private List<GameObject> list = new List<GameObject>();

    private void Awake()
    {
        status = GetComponent<Status>();
        nextCheck = checkRate + Time.time;
    }

    private void Update()
    {
        if (status.logicMatrix != null && nextCheck <= Time.time && status.active == true)
        {
            CheckLogicMatrix();
            nextCheck = checkRate + Time.time;
        }
    }

    private void FixedUpdate()
    {
        if (status.action != null && status.active == true)
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
            list = new List<GameObject>(status.inSightRange);
            for (int i = 0; i < objectCondition.Length; i++)
            {
                objectCondition[i].filterList(list);
            }

            if (list.Count >= 1)
            {
                return condition.Condition(list[0]);
            }
            return false;
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
            list = new List<GameObject>(status.inSightRange);
            for (int i = 0; i < objectAction.Length; i++)
            {
                objectAction[i].filterList(list);
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
