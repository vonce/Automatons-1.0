using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBrain : MonoBehaviour
{
    private Status status;
    //private float nextCheck;
    //[SerializeField]
    //private float checkRate;
    private GameObject objCheck;
    private int activeActionOption;
    public Vector3 targetDirection;

    public void MoveToTarget()
    {
        if (status.target != null)
        {
            targetDirection = Vector3.ProjectOnPlane(transform.position - status.target.transform.position, transform.up);
            transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward , -targetDirection.normalized, .1f, .1f), transform.up);
            transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.forward, status.speed * Time.deltaTime);
        }
    }

    public void RotateToTarget()
    {
        if (status.target != null)
        {
            targetDirection = Vector3.ProjectOnPlane(transform.position - status.target.transform.position, transform.up);
            transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, -targetDirection.normalized, .1f, .1f), transform.up);
        }
    }
    
    private void Awake()
    {
        GameObject.Find("LogicCheck").GetComponent<LogicCheck>().automatons.Add(gameObject);
        status = GetComponent<Status>();
        //nextCheck = checkRate + Time.time;
    }

    private void Start()
    {
        status.logicMatrix[0] = status.EnumToLogicGate(status.logicMatrixEnum[0]);
        status.logicMatrix[1] = status.EnumToLogicGate(status.logicMatrixEnum[1]);
        status.logicMatrix[2] = status.EnumToLogicGate(status.logicMatrixEnum[2]);
        status.logicMatrix[3] = status.EnumToLogicGate(status.logicMatrixEnum[3]);
    }

    /*private void Update()
    {
        if (status.logicMatrix != null && nextCheck <= Time.time && status.active == true)
        {
            //CheckLogicMatrix();
            //nextCheck = checkRate + Time.time;
        }
    }*/

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
            return action.ActionCheck(objectAction.Object(status.inSightRange, objectActionOption), actionOption);
        }
        else
        {
            return false;
        }
    }
}
