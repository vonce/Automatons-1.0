using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBrain : MonoBehaviour
{
    private Status status;
    private float nextCheck;
    [SerializeField]
    private float checkRate;
    private GameObject objCheck;
    private int activeActionOption;
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
    }

    private void Update()
    {
        if (status.logicMatrix != null && nextCheck <= Time.time && status.active == true)
        {
            CheckLogicMatrix();
            nextCheck = checkRate + Time.time;
            if (status.target != null)
            {
                Debug.Log(status.target.transform.position + "++++++++CHECK");
            }
        }
    }

    private void FixedUpdate()
    {
        if (status.action != null && status.active == true)
        {
            status.action.Action(status.target, activeActionOption);
        }
    }

    public void CheckLogicMatrix()//iterates through all logic matrices 
    {
        foreach (LogicGate logicGate in status.logicMatrix)
        {
            if (CheckCondition(logicGate.objectCondition, logicGate.objectConditionOption, logicGate.condition, logicGate.conditionOption) == true)
            {
                if (CheckAction(logicGate.objectAction, logicGate.objectActionOption, logicGate.action, logicGate.actionOption) == true)
                {
                    if (status.target != null)
                    {
                        Debug.Log(status.target.transform.position + "++++++++CHECK");
                    }
                    status.action = logicGate.action;
                    status.target = logicGate.objectAction.Object(status.inSightRange, logicGate.objectActionOption);
                    break;
                }
            }
        }
    }

    //Checks the OBJECTCONDITION against CONDITION, returns bool
    private bool CheckCondition(IObject objectCondition, int objectConditionOption, ICondition condition, int conditionOption)
    {
        if (objectCondition != null && condition != null)
        {
            return condition.Condition(objectCondition.Object(status.inSightRange, objectConditionOption), conditionOption);
        }
        else
        {
            return false;
        }
    }

    //Checks the OBJECTACTION against ACTION, returns bool
    private bool CheckAction(IObject objectAction, int objectActionOption, IAction action, int actionOption)
    {
        if (objectAction != null && action != null)
        {
            if (status.target != null)
            {
                Debug.Log(status.target.transform.position + "CHECK ACTION TRUE");
            }
            return action.ActionCheck(objectAction.Object(status.inSightRange, objectActionOption), actionOption);
        }
        else
        {
            if (status.target != null)
            {
                Debug.Log(status.target.transform.position + "CHECK ACTION FALSE");
            }
            return false;
        }
    }
}
