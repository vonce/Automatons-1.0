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

    private void Start()
    {
        status.logicMatrix[0] = status.EnumToLogicGate(status.logicMatrixEnum[0]);
        status.logicMatrix[1] = status.EnumToLogicGate(status.logicMatrixEnum[1]);
        status.logicMatrix[2] = status.EnumToLogicGate(status.logicMatrixEnum[2]);
        status.logicMatrix[3] = status.EnumToLogicGate(status.logicMatrixEnum[3]);
        status.logicMatrix[4] = status.EnumToLogicGate(status.logicMatrixEnum[4]);
    }

    private void Update()
    {
        if (status.logicMatrix != null && nextCheck <= Time.time && status.active == true)
        {
            status.logicMatrix[0] = status.EnumToLogicGate(status.logicMatrixEnum[0]);
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
            if (list.Count > 0)
            {
                objCheck = list[0];
                foreach (GameObject obj in list)
                {
                    if (objCheck != null && obj != null && Vector3.Distance(gameObject.transform.position, obj.transform.position) < Vector3.Distance(gameObject.transform.position, objCheck.transform.position))
                    {
                        objCheck = obj;
                    }
                }
                return condition.Condition(objCheck);
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
                    if (objCheck != null && obj != null && Vector3.Distance(gameObject.transform.position, obj.transform.position) < Vector3.Distance(gameObject.transform.position, objCheck.transform.position))
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
