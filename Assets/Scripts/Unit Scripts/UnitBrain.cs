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
    private GameObject objCheck;
    public Vector3 moveDirection;

    public void MoveToTarget()
    {
        if (status.target != null)
        {
            moveDirection = Vector3.ProjectOnPlane(transform.position - status.target.transform.position, transform.up);
            transform.rotation = Quaternion.LookRotation(-moveDirection, transform.up);
            transform.position = Vector3.MoveTowards(transform.position, transform.position - moveDirection, status.speed * Time.deltaTime);
        }
    }

    public void RotateToTarget()
    {
        if (status.target != null)
        {
            moveDirection = Vector3.ProjectOnPlane(transform.position - status.target.transform.position, transform.up);
            transform.rotation = Quaternion.LookRotation(-moveDirection, transform.up);
        }
    }
    
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
            if (list.Count > 0)
            {
                objCheck = list[0];
                foreach (GameObject obj in list)
                {
                    if (obj != null && Vector3.Distance(gameObject.transform.position, obj.transform.position) < Vector3.Distance(gameObject.transform.position, objCheck.transform.position))
                    {
                        objCheck = obj;
                    }
                }
                if (action.ActionCheck(objCheck) == true)
                {
                    status.target = objCheck;
                    return action.ActionCheck(status.target);
                }
                return false;
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
