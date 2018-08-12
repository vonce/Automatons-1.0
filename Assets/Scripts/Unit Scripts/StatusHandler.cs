﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private LogicGateEnum logicGateToEnum(LogicGate logicGate)
    {
        LogicGateEnum logicGateEnum = new LogicGateEnum();

        logicGateEnum.objectCondition = new ObjectE[logicGate.objectCondition.Length];
        for (int i = 0; i < logicGate.objectCondition.Length; i++)
        {
            logicGateEnum.objectCondition[i] = logicGate.objectCondition[i].enumID();
        }
        logicGateEnum.condition = logicGate.condition.enumID();
        logicGateEnum.action = logicGate.action.enumID();

        logicGateEnum.objectAction = new ObjectE[logicGate.objectAction.Length];
        for (int i = 0; i < logicGate.objectAction.Length; i++)
        {
            logicGateEnum.objectAction[i] = logicGate.objectAction[i].enumID();
        }

        return logicGateEnum;
    }
}
