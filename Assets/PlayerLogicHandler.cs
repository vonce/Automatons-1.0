using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLogicHandler : MonoBehaviour {

    public LogicGateEnum[] logicMatrixEnum = new LogicGateEnum[6];

    [SerializeField]
    private CanvasRenderer copyButton;
    [SerializeField]
    private CanvasRenderer pasteButton;

    private PlayerSelect playerSelect;

    private PrimaryTypeE primaryType;
    private SecondaryTypeE secondaryType;
    private SpecialTypeE specialType;

    [SerializeField]
    private Dropdown primaryTypeDropdown;
    [SerializeField]
    private Dropdown secondaryTypeDropdown;
    [SerializeField]
    private Dropdown specialTypeDropdown;

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
    void PrimaryDropdown(Dropdown dropdown)
    {
        List<string> objlistnames = new List<string>();
        string[] objnames = PrimaryTypeE.GetNames(typeof(PrimaryTypeE));
        foreach (string i in objnames)
        {
            objlistnames.Add(i);
        }
        dropdown.ClearOptions();
        dropdown.AddOptions(objlistnames);
    }

    void SecondaryDropdown(Dropdown dropdown)
    {
        List<string> objlistnames = new List<string>();
        string[] objnames = SecondaryTypeE.GetNames(typeof(SecondaryTypeE));
        foreach (string i in objnames)
        {
            objlistnames.Add(i);
        }
        dropdown.ClearOptions();
        dropdown.AddOptions(objlistnames);
    }

    void SpecialDropdown(Dropdown dropdown)
    {
        List<string> objlistnames = new List<string>();
        string[] objnames = SpecialTypeE.GetNames(typeof(SpecialTypeE));
        foreach (string i in objnames)
        {
            objlistnames.Add(i);
        }
        dropdown.ClearOptions();
        dropdown.AddOptions(objlistnames);
    }

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
        playerSelect = gameObject.GetComponent<PlayerSelect>();

        primaryTypeDropdown.onValueChanged.AddListener(delegate { DropdownValueChanged(); });
        secondaryTypeDropdown.onValueChanged.AddListener(delegate { DropdownValueChanged(); });
        specialTypeDropdown.onValueChanged.AddListener(delegate { DropdownValueChanged(); });

        objectConditionDropdownA1.onValueChanged.AddListener(delegate { DropdownValueChanged(); });
        objectConditionDropdownB1.onValueChanged.AddListener(delegate { DropdownValueChanged(); });
        objectConditionDropdownA2.onValueChanged.AddListener(delegate { DropdownValueChanged(); });
        objectConditionDropdownB2.onValueChanged.AddListener(delegate { DropdownValueChanged(); });
        objectConditionDropdownA3.onValueChanged.AddListener(delegate { DropdownValueChanged(); });
        objectConditionDropdownB3.onValueChanged.AddListener(delegate { DropdownValueChanged(); });
        objectConditionDropdownA4.onValueChanged.AddListener(delegate { DropdownValueChanged(); });
        objectConditionDropdownB4.onValueChanged.AddListener(delegate { DropdownValueChanged(); });
        objectConditionDropdownA5.onValueChanged.AddListener(delegate { DropdownValueChanged(); });
        objectConditionDropdownB5.onValueChanged.AddListener(delegate { DropdownValueChanged(); });

        conditionDropdown1.onValueChanged.AddListener(delegate { DropdownValueChanged(); });
        conditionDropdown2.onValueChanged.AddListener(delegate { DropdownValueChanged(); });
        conditionDropdown3.onValueChanged.AddListener(delegate { DropdownValueChanged(); });
        conditionDropdown4.onValueChanged.AddListener(delegate { DropdownValueChanged(); });
        conditionDropdown5.onValueChanged.AddListener(delegate { DropdownValueChanged(); });

        actionDropdown1.onValueChanged.AddListener(delegate { DropdownValueChanged(); });
        actionDropdown2.onValueChanged.AddListener(delegate { DropdownValueChanged(); });
        actionDropdown3.onValueChanged.AddListener(delegate { DropdownValueChanged(); });
        actionDropdown4.onValueChanged.AddListener(delegate { DropdownValueChanged(); });
        actionDropdown5.onValueChanged.AddListener(delegate { DropdownValueChanged(); });

        objectActionDropdownA1.onValueChanged.AddListener(delegate { DropdownValueChanged(); });
        objectActionDropdownB1.onValueChanged.AddListener(delegate { DropdownValueChanged(); });
        objectActionDropdownA2.onValueChanged.AddListener(delegate { DropdownValueChanged(); });
        objectActionDropdownB2.onValueChanged.AddListener(delegate { DropdownValueChanged(); });
        objectActionDropdownA3.onValueChanged.AddListener(delegate { DropdownValueChanged(); });
        objectActionDropdownB3.onValueChanged.AddListener(delegate { DropdownValueChanged(); });
        objectActionDropdownA4.onValueChanged.AddListener(delegate { DropdownValueChanged(); });
        objectActionDropdownB4.onValueChanged.AddListener(delegate { DropdownValueChanged(); });
        objectActionDropdownA5.onValueChanged.AddListener(delegate { DropdownValueChanged(); });
        objectActionDropdownB5.onValueChanged.AddListener(delegate { DropdownValueChanged(); });

        PrimaryDropdown(primaryTypeDropdown);
        SecondaryDropdown(secondaryTypeDropdown);
        SpecialDropdown(specialTypeDropdown);

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

        Apply();
    }

    void DropdownValueChanged ()
    {
        if (primaryTypeDropdown.value != (int)primaryType) { primaryTypeDropdown.captionText.color = Color.red; } else { primaryTypeDropdown.captionText.color = Color.green; }
        if (secondaryTypeDropdown.value != (int)secondaryType) { secondaryTypeDropdown.captionText.color = Color.red; } else { secondaryTypeDropdown.captionText.color = Color.green; }
        if (specialTypeDropdown.value != (int)specialType) { specialTypeDropdown.captionText.color = Color.red; } else { specialTypeDropdown.captionText.color = Color.green; }

        if (objectConditionDropdownA1.value != (int)logicMatrixEnum[0].objectCondition[0]) { objectConditionDropdownA1.captionText.color = Color.red; } else { objectConditionDropdownA1.captionText.color = Color.green; }
        if (objectConditionDropdownB1.value != (int)logicMatrixEnum[0].objectCondition[1]) { objectConditionDropdownB1.captionText.color = Color.red; } else { objectConditionDropdownB1.captionText.color = Color.green; }
        if (conditionDropdown1.value != (int)logicMatrixEnum[0].condition) { conditionDropdown1.captionText.color = Color.red; } else { conditionDropdown1.captionText.color = Color.green; }
        if (actionDropdown1.value != (int)logicMatrixEnum[0].action) { actionDropdown1.captionText.color = Color.red; } else { actionDropdown1.captionText.color = Color.green; }
        if (objectActionDropdownA1.value != (int)logicMatrixEnum[0].objectAction[0]) { objectActionDropdownA1.captionText.color = Color.red; } else { objectActionDropdownA1.captionText.color = Color.green; }
        if (objectActionDropdownB1.value != (int)logicMatrixEnum[0].objectAction[1]) { objectActionDropdownB1.captionText.color = Color.red; } else { objectActionDropdownB1.captionText.color = Color.green; }

        if (objectConditionDropdownA2.value != (int)logicMatrixEnum[1].objectCondition[0]) { objectConditionDropdownA2.captionText.color = Color.red; } else { objectConditionDropdownA2.captionText.color = Color.green; }
        if (objectConditionDropdownB2.value != (int)logicMatrixEnum[1].objectCondition[1]) { objectConditionDropdownB2.captionText.color = Color.red; } else { objectConditionDropdownB2.captionText.color = Color.green; }
        if (conditionDropdown2.value != (int)logicMatrixEnum[1].condition) { conditionDropdown2.captionText.color = Color.red; } else { conditionDropdown2.captionText.color = Color.green; }
        if (actionDropdown2.value != (int)logicMatrixEnum[1].action) { actionDropdown2.captionText.color = Color.red; } else { actionDropdown2.captionText.color = Color.green; }
        if (objectActionDropdownA2.value != (int)logicMatrixEnum[1].objectAction[0]) { objectActionDropdownA2.captionText.color = Color.red; } else { objectActionDropdownA2.captionText.color = Color.green; }
        if (objectActionDropdownB2.value != (int)logicMatrixEnum[1].objectAction[1]) { objectActionDropdownB2.captionText.color = Color.red; } else { objectActionDropdownB2.captionText.color = Color.green; }

        if (objectConditionDropdownA3.value != (int)logicMatrixEnum[2].objectCondition[0]) { objectConditionDropdownA3.captionText.color = Color.red; } else { objectConditionDropdownA3.captionText.color = Color.green; }
        if (objectConditionDropdownB3.value != (int)logicMatrixEnum[2].objectCondition[1]) { objectConditionDropdownB3.captionText.color = Color.red; } else { objectConditionDropdownB3.captionText.color = Color.green; }
        if (conditionDropdown3.value != (int)logicMatrixEnum[2].condition) { conditionDropdown3.captionText.color = Color.red; } else { conditionDropdown3.captionText.color = Color.green; }
        if (actionDropdown3.value != (int)logicMatrixEnum[2].action) { actionDropdown3.captionText.color = Color.red; } else { actionDropdown3.captionText.color = Color.green; }
        if (objectActionDropdownA3.value != (int)logicMatrixEnum[2].objectAction[0]) { objectActionDropdownA3.captionText.color = Color.red; } else { objectActionDropdownA3.captionText.color = Color.green; }
        if (objectActionDropdownB3.value != (int)logicMatrixEnum[2].objectAction[1]) { objectActionDropdownB3.captionText.color = Color.red; } else { objectActionDropdownB3.captionText.color = Color.green; }

        if (objectConditionDropdownA4.value != (int)logicMatrixEnum[3].objectCondition[0]) { objectConditionDropdownA4.captionText.color = Color.red; } else { objectConditionDropdownA4.captionText.color = Color.green; }
        if (objectConditionDropdownB4.value != (int)logicMatrixEnum[3].objectCondition[1]) { objectConditionDropdownB4.captionText.color = Color.red; } else { objectConditionDropdownB4.captionText.color = Color.green; }
        if (conditionDropdown4.value != (int)logicMatrixEnum[3].condition) { conditionDropdown4.captionText.color = Color.red; } else { conditionDropdown4.captionText.color = Color.green; }
        if (actionDropdown4.value != (int)logicMatrixEnum[3].action) { actionDropdown4.captionText.color = Color.red; } else { actionDropdown4.captionText.color = Color.green; }
        if (objectActionDropdownA4.value != (int)logicMatrixEnum[3].objectAction[0]) { objectActionDropdownA4.captionText.color = Color.red; } else { objectActionDropdownA4.captionText.color = Color.green; }
        if (objectActionDropdownB4.value != (int)logicMatrixEnum[3].objectAction[1]) { objectActionDropdownB4.captionText.color = Color.red; } else { objectActionDropdownB4.captionText.color = Color.green; }

        if (objectConditionDropdownA5.value != (int)logicMatrixEnum[4].objectCondition[0]) { objectConditionDropdownA5.captionText.color = Color.red; } else { objectConditionDropdownA5.captionText.color = Color.green; }
        if (objectConditionDropdownB5.value != (int)logicMatrixEnum[4].objectCondition[1]) { objectConditionDropdownB5.captionText.color = Color.red; } else { objectConditionDropdownB5.captionText.color = Color.green; }
        if (conditionDropdown5.value != (int)logicMatrixEnum[4].condition) { conditionDropdown5.captionText.color = Color.red; } else { conditionDropdown5.captionText.color = Color.green; }
        if (actionDropdown5.value != (int)logicMatrixEnum[4].action) { actionDropdown5.captionText.color = Color.red; } else { actionDropdown5.captionText.color = Color.green; }
        if (objectActionDropdownA5.value != (int)logicMatrixEnum[4].objectAction[0]) { objectActionDropdownA5.captionText.color = Color.red; } else { objectActionDropdownA5.captionText.color = Color.green; }
        if (objectActionDropdownB5.value != (int)logicMatrixEnum[4].objectAction[1]) { objectActionDropdownB5.captionText.color = Color.red; } else { objectActionDropdownB5.captionText.color = Color.green; }
    }
    public void Copy()
    {

    }

    public void Paste()
    {

    }

    public void Apply ()
    {
        primaryType = (PrimaryTypeE)primaryTypeDropdown.value;
        secondaryType = (SecondaryTypeE)secondaryTypeDropdown.value;
        specialType = (SpecialTypeE)specialTypeDropdown.value;

        logicMatrixEnum[0] = LogicGateEnumChange((ObjectE)objectConditionDropdownA1.value, (ObjectE)objectConditionDropdownB1.value, (ConditionE)conditionDropdown1.value, (ActionE)actionDropdown1.value, (ObjectE)objectActionDropdownA1.value, (ObjectE)objectActionDropdownB1.value);
        logicMatrixEnum[1] = LogicGateEnumChange((ObjectE)objectConditionDropdownA2.value, (ObjectE)objectConditionDropdownB2.value, (ConditionE)conditionDropdown2.value, (ActionE)actionDropdown2.value, (ObjectE)objectActionDropdownA2.value, (ObjectE)objectActionDropdownB2.value);
        logicMatrixEnum[2] = LogicGateEnumChange((ObjectE)objectConditionDropdownA3.value, (ObjectE)objectConditionDropdownB3.value, (ConditionE)conditionDropdown3.value, (ActionE)actionDropdown3.value, (ObjectE)objectActionDropdownA3.value, (ObjectE)objectActionDropdownB3.value);
        logicMatrixEnum[3] = LogicGateEnumChange((ObjectE)objectConditionDropdownA4.value, (ObjectE)objectConditionDropdownB4.value, (ConditionE)conditionDropdown4.value, (ActionE)actionDropdown4.value, (ObjectE)objectActionDropdownA4.value, (ObjectE)objectActionDropdownB4.value);
        logicMatrixEnum[4] = LogicGateEnumChange((ObjectE)objectConditionDropdownA5.value, (ObjectE)objectConditionDropdownB5.value, (ConditionE)conditionDropdown5.value, (ActionE)actionDropdown5.value, (ObjectE)objectActionDropdownA5.value, (ObjectE)objectActionDropdownB5.value);

        if (playerSelect.selected.Count > 0)
        {
            foreach (GameObject obj in playerSelect.selected)
            {
                obj.GetComponent<Status>().logicMatrixEnum = logicMatrixEnum;
                obj.GetComponent<Status>().primaryType = (PrimaryTypeE)primaryTypeDropdown.value;
                obj.GetComponent<Status>().secondaryType = (SecondaryTypeE)secondaryTypeDropdown.value;
                obj.GetComponent<Status>().specialType = (SpecialTypeE)specialTypeDropdown.value;
            }
        }
        DropdownValueChanged();
    }

    public void SetDropdowns (LogicGateEnum[] matrix, PrimaryTypeE primary, SecondaryTypeE secondary, SpecialTypeE special)
    {
        primaryType = primary;
        secondaryType = secondary;
        specialType = special;

        logicMatrixEnum = matrix;

        primaryTypeDropdown.value = (int)primary;
        secondaryTypeDropdown.value = (int)secondary;
        specialTypeDropdown.value = (int)special;

        objectConditionDropdownA1.value = (int)matrix[0].objectCondition[0];
        objectConditionDropdownB1.value = (int)matrix[0].objectCondition[1];
        conditionDropdown1.value = (int)matrix[0].condition;
        actionDropdown1.value = (int)matrix[0].action;
        objectActionDropdownA1.value = (int)matrix[0].objectAction[0];
        objectActionDropdownB1.value = (int)matrix[0].objectAction[1];

        objectConditionDropdownA2.value = (int)matrix[1].objectCondition[0];
        objectConditionDropdownB2.value = (int)matrix[1].objectCondition[1];
        conditionDropdown2.value = (int)matrix[1].condition;
        actionDropdown2.value = (int)matrix[1].action;
        objectActionDropdownA2.value = (int)matrix[1].objectAction[0];
        objectActionDropdownB2.value = (int)matrix[1].objectAction[1];

        objectConditionDropdownA3.value = (int)matrix[2].objectCondition[0];
        objectConditionDropdownB3.value = (int)matrix[2].objectCondition[1];
        conditionDropdown3.value = (int)matrix[2].condition;
        actionDropdown3.value = (int)matrix[2].action;
        objectActionDropdownA3.value = (int)matrix[2].objectAction[0];
        objectActionDropdownB3.value = (int)matrix[2].objectAction[1];

        objectConditionDropdownA4.value = (int)matrix[3].objectCondition[0];
        objectConditionDropdownB4.value = (int)matrix[3].objectCondition[1];
        conditionDropdown4.value = (int)matrix[3].condition;
        actionDropdown4.value = (int)matrix[3].action;
        objectActionDropdownA4.value = (int)matrix[3].objectAction[0];
        objectActionDropdownB4.value = (int)matrix[3].objectAction[1];

        objectConditionDropdownA5.value = (int)matrix[4].objectCondition[0];
        objectConditionDropdownB5.value = (int)matrix[4].objectCondition[1];
        conditionDropdown5.value = (int)matrix[4].condition;
        actionDropdown5.value = (int)matrix[4].action;
        objectActionDropdownA5.value = (int)matrix[4].objectAction[0];
        objectActionDropdownB5.value = (int)matrix[4].objectAction[1];
    }

    private LogicGateEnum LogicGateEnumChange(ObjectE objectConditionA, ObjectE objectConditionB, ConditionE condition, ActionE action, ObjectE objectActionA, ObjectE objectActionB)
    {
        LogicGateEnum lg = new LogicGateEnum();
        lg.objectCondition = new ObjectE[2];
        lg.objectAction = new ObjectE[2];

        lg.objectCondition[0] = objectConditionA;
        lg.objectCondition[1] = objectConditionB;
        lg.condition = condition;
        lg.action = action;
        lg.objectAction[0] = objectActionA;
        lg.objectAction[1] = objectActionB;

        return lg;
    }
}
