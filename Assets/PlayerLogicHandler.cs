using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLogicHandler : MonoBehaviour {

    private LogicGateEnum[] logicGateEnum = new LogicGateEnum[6];

    [SerializeField]
    private Dropdown objectConditionDropdownA1;
    [SerializeField]
    private Dropdown objectConditionDropdownB1;
    [SerializeField]
    private Dropdown conditionDropdown1;
    [SerializeField]
    private Dropdown actionDropdown1;
    [SerializeField]
    private Dropdown objectActionDropdownA1;
    [SerializeField]
    private Dropdown objectActionDropdownB1;

    [SerializeField]
    private Dropdown objectConditionDropdownA2;
    [SerializeField]
    private Dropdown objectConditionDropdownB2;
    [SerializeField]
    private Dropdown conditionDropdown2;
    [SerializeField]
    private Dropdown actionDropdown2;
    [SerializeField]
    private Dropdown objectActionDropdownA2;
    [SerializeField]
    private Dropdown objectActionDropdownB2;

    [SerializeField]
    private Dropdown objectConditionDropdownA3;
    [SerializeField]
    private Dropdown objectConditionDropdownB3;
    [SerializeField]
    private Dropdown conditionDropdown3;
    [SerializeField]
    private Dropdown actionDropdown3;
    [SerializeField]
    private Dropdown objectActionDropdownA3;
    [SerializeField]
    private Dropdown objectActionDropdownB3;

    [SerializeField]
    private Dropdown objectConditionDropdownA4;
    [SerializeField]
    private Dropdown objectConditionDropdownB4;
    [SerializeField]
    private Dropdown conditionDropdown4;
    [SerializeField]
    private Dropdown actionDropdown4;
    [SerializeField]
    private Dropdown objectActionDropdownA4;
    [SerializeField]
    private Dropdown objectActionDropdownB4;

    [SerializeField]
    private Dropdown objectConditionDropdownA5;
    [SerializeField]
    private Dropdown objectConditionDropdownB5;
    [SerializeField]
    private Dropdown conditionDropdown5;
    [SerializeField]
    private Dropdown actionDropdown5;
    [SerializeField]
    private Dropdown objectActionDropdownA5;
    [SerializeField]
    private Dropdown objectActionDropdownB5;

    //populate dropdown menus with enum values
    void ObjectDropdown(Dropdown dropdown)
    {
        List<string> objlistnames = new List<string>();
        string[] objnames = ObjectE.GetNames(typeof(ObjectE));
        foreach (string i in objnames)
        {
            objlistnames.Add(i);
        }
        dropdown.ClearOptions();
        dropdown.AddOptions(objlistnames);
    }

    void ConditionDropdown(Dropdown dropdown)
    {
        List<string> condlistnames = new List<string>();
        string[] condnames = ConditionE.GetNames(typeof(ConditionE));
        foreach (string i in condnames)
        {
            condlistnames.Add(i);
        }
        dropdown.ClearOptions();
        dropdown.AddOptions(condlistnames);
    }

    void ActionDropdown(Dropdown dropdown)
    {
        List<string> actlistnames = new List<string>();
        string[] actnames = ActionE.GetNames(typeof(ActionE));
        foreach (string i in actnames)
        {
            actlistnames.Add(i);
        }
        dropdown.ClearOptions();
        dropdown.AddOptions(actlistnames);
    }

    private void Awake()
    {
        ObjectDropdown(objectConditionDropdownA1);
        ObjectDropdown(objectConditionDropdownB1);
        ObjectDropdown(objectConditionDropdownA2);
        ObjectDropdown(objectConditionDropdownB2);
        ObjectDropdown(objectConditionDropdownA3);
        ObjectDropdown(objectConditionDropdownB3);
        ObjectDropdown(objectConditionDropdownA4);
        ObjectDropdown(objectConditionDropdownB4);
        ObjectDropdown(objectConditionDropdownA5);
        ObjectDropdown(objectConditionDropdownB5);
        
        ConditionDropdown(conditionDropdown1);
        ConditionDropdown(conditionDropdown2);
        ConditionDropdown(conditionDropdown3);
        ConditionDropdown(conditionDropdown4);
        ConditionDropdown(conditionDropdown5);

        ActionDropdown(actionDropdown1);
        ActionDropdown(actionDropdown2);
        ActionDropdown(actionDropdown3);
        ActionDropdown(actionDropdown4);
        ActionDropdown(actionDropdown5);

        ObjectDropdown(objectActionDropdownA1);
        ObjectDropdown(objectActionDropdownB1);
        ObjectDropdown(objectActionDropdownA2);
        ObjectDropdown(objectActionDropdownB2);
        ObjectDropdown(objectActionDropdownA3);
        ObjectDropdown(objectActionDropdownB3);
        ObjectDropdown(objectActionDropdownA4);
        ObjectDropdown(objectActionDropdownB4);
        ObjectDropdown(objectActionDropdownA5);
        ObjectDropdown(objectActionDropdownB5);
    }

}
