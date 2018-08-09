using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handles health, special, status effects.

public class UnitStatus : StatusHandler
{
    public LogicGateEnum[] LogicMatrixEnum = new LogicGateEnum[6];
    private LogicGate[] logicMatrix = new LogicGate[6];
    [SerializeField]
    private IAction action; //action gameObject is taking
    [SerializeField]
    private GameObject target; //target of gameObject
    private HashSet<GameObject> inSightRange = new HashSet<GameObject>();//hashset of objects in sight range
    private HashSet<GameObject> inAttackRange = new HashSet<GameObject>();//hashset of objects in attack range
    public PrimaryTypeE primaryType;//primary weapon type
    public SecondaryTypeE secondaryType;//secondary weapon type
    public SpecialTypeE specialType;//special type
    public HashSet<int> statusEffects;//hashset of status effects

    private void Start()
    {
        HealthChange(-7);
        SpecialChange(-2);
    }

    private void Update()
    {
        if (logicMatrix != null)
        {
            CheckLogicMatrix();
        }
    }

    private void FixedUpdate()
    {
        if (action != null)
        {
            action.Action(target);
        }
    }

    public void CheckLogicMatrix()
    {
        foreach (LogicGate i in logicMatrix)
        {
            if (CheckCondition(i.objectCondition, i.condition) == true)
            {
                if (CheckAction(i.objectAction, i.action) == true)
                {
                    target = i.objectAction.Objects(inSightRange)[0];
                    action = i.action;
                    break;
                }
            }
        }
    }
    //Checks the OBJECTCONDITION against CONDITION, returns bool
    private bool CheckCondition(IObject objectCondition, ICondition condition)
    {
        if (objectCondition != null && condition != null)
        {
            return condition.Condition(objectCondition.Objects(inSightRange)[0]);
        }
        else
        {
            return false;
        }
    }

    //Checks the OBJECTACTION against ACTION, returns bool
    private bool CheckAction(IObject objectAction, IAction action)
    {
        return action.ActionCheck(objectAction.Objects(inSightRange)[0]);
    }
}
