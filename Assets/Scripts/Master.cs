using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// enums to handle logic gates, unit types, and weapons

public enum UnitTypeE { Command = 0, Factory = 1, Refinery = 2, Automaton = 3 };
public enum ObjectE { EnemyCommand = 0, AllyCommand = 1, LowestHealthEnemy = 2, NearestAlly = 3, NearestEnemy = 4, Self = 5 };
public enum ConditionE { Always = 0, LessThanHealth = 1, MoreThanHealth = 2 };
public enum ActionE { Primary = 0, Secondary = 1, Special = 2, Move = 3,  };
public enum UnitBuildingE { Unit = 0, Building = 1 };
public enum PrimaryTypeE { Beam = 0, Laser = 1, Grenade = 2 };
public enum SecondaryTypeE { Rocket = 0, Heal = 1, Lightning = 2, Napalm = 3, Virus = 4 };
public enum SpecialTypeE { Lightning = 0, Napalm = 1, Virus = 2 };
public enum StatusE { None = 0, Overload = 1, Oiled = 2, Galvanized = 3, ShortCircuit = 4, Fire = 5, Corrosion = 6, Virus = 7 }

//interfaces for logicgates.


public interface IObject
{
    ObjectE enumID();
    GameObject[] Objects(HashSet<GameObject> objectList);
    GameObject[] Objects(HashSet<GameObject> objectList, params IObject[] objectParameters);
}

public interface ICondition
{
    ConditionE enumID();
    bool Condition(GameObject target);
    bool Condition(GameObject target, int option);
}

public interface IAction
{
    ActionE enumID();
    bool ActionCheck(GameObject target);
    void Action(GameObject target);
}

// logic gate and matrix format

public struct LogicGate
{
    public IObject objectCondition;//the object the conditional statement is based
    public ICondition condition;//the condition
    public IAction action;//the action
    public IObject objectAction;//the object the action is performed on
}

public struct LogicGateEnum//enum format for logic gate
{
    public ObjectE objectCondition;
    public ConditionE condition;
    public ActionE action;
    public ObjectE objectAction;
}

public struct Spherical
{
    public float radius;
    public float theta;
    public float phi;
}