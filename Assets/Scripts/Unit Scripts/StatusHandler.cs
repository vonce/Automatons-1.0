using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StatusHandler : MonoBehaviour
{
    public bool active = false;
    public float speed;
    public float attackSpeed;
    public float sightRange;
    public float attackRange;
    public int attackPower;
    public int defense;
    [SerializeField]
    private int maxHealth;
    [SerializeField]
    private int maxSpecial;
    [SerializeField]
    private int currentHealth;
    [SerializeField]
    private int currentSpecial;
    [SerializeField]
    private GameObject healthBar;
    [SerializeField]
    private GameObject specialBar;

    private void SetHealthBar(float unitHealth)//changes healthbar size
    {
        healthBar.transform.localScale = new Vector3(unitHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }
    private void SetSpecialBar(float unitSpecial)//changes specialbar size
    {
        specialBar.transform.localScale = new Vector3(unitSpecial, specialBar.transform.localScale.y, specialBar.transform.localScale.z);
    }

    public void HealthChange(int amount)//method used for all health changes
    {
        if (amount - defense > 0)
        {
            currentHealth = currentHealth + (amount - defense);
        }
        else
        {
            currentHealth = currentHealth + amount;
        }
        SetHealthBar((float) currentHealth / maxHealth);
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void SpecialChange(int amount)//method used for all special changes
    {
        currentSpecial = currentSpecial + amount;
        SetSpecialBar((float) currentSpecial / maxSpecial);
    }

    public LogicGateEnum logicGateToEnum(LogicGate logicGate)
    {
        LogicGateEnum logicGateEnum = new LogicGateEnum();

        logicGateEnum.objectCondition = logicGate.objectCondition.enumID();
        logicGateEnum.objectConditionOption = logicGate.objectConditionOption;
        logicGateEnum.condition = logicGate.condition.enumID();
        logicGateEnum.conditionOption = logicGate.conditionOption;
        logicGateEnum.action = logicGate.action.enumID();
        logicGateEnum.actionOption = logicGate.actionOption;
        logicGateEnum.objectAction = logicGate.objectAction.enumID();
        logicGateEnum.objectActionOption = logicGate.objectActionOption;

        return logicGateEnum;
    }

    public LogicGate EnumToLogicGate(LogicGateEnum logicGateEnum)
    {
        LogicGate logicGate = new LogicGate();
        
        var objects = GetComponents<MonoBehaviour>().OfType<IObject>();
        var conditions = GetComponents<MonoBehaviour>().OfType<ICondition>();
        var actions = GetComponents<MonoBehaviour>().OfType<IAction>();

        foreach (IObject obj in objects)
        {
            if (logicGateEnum.objectCondition == obj.enumID())
            {
                logicGate.objectCondition = obj;
            }

            if (logicGateEnum.objectAction == obj.enumID())
            {
                logicGate.objectAction = obj;
            }
        }
        foreach (ICondition cond in conditions)
        {
            if (logicGateEnum.condition == cond.enumID())
            {
                logicGate.condition = cond;
            }
        }
        foreach (IAction act in actions)
        {
            if (logicGateEnum.action == act.enumID())
            {
                logicGate.action = act;
            }
        }

        logicGate.objectConditionOption = logicGateEnum.objectConditionOption;
        logicGate.conditionOption = logicGateEnum.conditionOption;
        logicGate.actionOption = logicGateEnum.actionOption;
        logicGate.objectActionOption = logicGateEnum.objectActionOption;

        return logicGate;
    }
}
