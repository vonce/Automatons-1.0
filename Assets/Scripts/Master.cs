using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// enums to handle logic gates, unit types, and weapons

public enum UnitTypeE { Base = 0, Factory = 1, Refinery = 2, Emitter = 3, Turret = 4, Automaton = 5 };
public enum ObjectE { Self = 0, Enemy = 1, Allied = 2};
public enum ConditionE { Always = 0, LessThanHealth = 1, MoreThanHealth = 2, LessThanSpecial = 3, MoreThanSpecial = 4 };
public enum ActionE { Primary = 0, Secondary = 1, Special = 2, Move = 3,  };
public enum UnitBuildingE { Unit = 0, Building = 1 };
public enum PrimaryTypeE { Gun = 0, Beam = 1, Grenade = 2 };
public enum SecondaryTypeE { Rocket = 0, HealBeam = 1, }; //Lightning = 2, Napalm = 3, Virus = 4 };
public enum SpecialTypeE { Lightning = 0 };//, Napalm = 1, Virus = 2 };

public enum StatusE { None = 0, SuperCharged = 1, Oiled = 2, Galvanized = 3, Networked = 4, ShortCircuit = 5, Fire = 6, Corrosion = 7, Virus = 8 }

public enum ObjectOptionE { Nearest = 0, Farthest = 1, Base = 2, Factory = 3, Refinery = 4, Emitter = 5, Turret = 6, Automaton = 7 }
public enum NoneE { None = 0 }
public enum PercentE { ZeroPct = 0, TenPct = 1, TwentyPct = 2, ThirtyPct = 3, FortyPct = 4, FiftyPct = 5, SixtyPct = 6, SeventyPct = 7, EightyPct = 8, NinetyPct = 9, HundredPct = 10 }


//interfaces for logicgates.
public interface IObject
{
    ObjectE enumID();
    GameObject Object(HashSet<GameObject> set, int option);
}

public interface ICondition
{
    ConditionE enumID();
    bool Condition(GameObject target, int option);
}

public interface IAction
{
    ActionE enumID();
    bool ActionCheck(GameObject target, int option);
    void Action(GameObject target, int option);
}

// logic gate and matrix format

public struct LogicGate
{
    public IObject objectCondition;//the object the conditional statement is based
    public int objectConditionOption;
    public ICondition condition;//the condition
    public int conditionOption;
    public IAction action;//the action
    public int actionOption;
    public IObject objectAction;//the object the action is performed on
    public int objectActionOption;
}

public struct LogicGateEnum//enum format for logic gate
{
    public ObjectE objectCondition;
    public int objectConditionOption;
    public ConditionE condition;
    public int conditionOption;
    public ActionE action;
    public int actionOption;
    public ObjectE objectAction;
    public int objectActionOption;
}

public struct Spherical//spherical coordinates
{
    public float radius;
    public float theta;
    public float phi;
}