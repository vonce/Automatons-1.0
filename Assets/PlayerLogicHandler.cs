using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLogicHandler : MonoBehaviour {

    public LogicGateEnum[] logicMatrixEnum = new LogicGateEnum[4];
    public LogicGateEnum[] defaultLogicMatrixEnum = new LogicGateEnum[4];
    private LogicGateEnum[] copiedLogicMatrixEnum = new LogicGateEnum[4];
    private Dictionary<System.Enum, System.Enum> enumDictionary = new Dictionary<System.Enum, System.Enum>();

    private PrimaryTypeE primary;
    private SecondaryTypeE secondary;
    private SpecialTypeE special;
    
    [SerializeField]
    private CanvasRenderer copyButton;
    [SerializeField]
    private CanvasRenderer pasteButton;

    private PlayerSelect playerSelect;

    [SerializeField]
    private Dropdown objectConditionDropdown0;
    [SerializeField]
    private Dropdown objectConditionOptionDropdown0;
    [SerializeField]
    private Dropdown conditionDropdown0;
    [SerializeField]
    private Dropdown conditionOptionDropdown0;
    [SerializeField]
    private Dropdown actionDropdown0;
    [SerializeField]
    private Dropdown actionOptionDropdown0;
    [SerializeField]
    private Dropdown objectActionDropdown0;
    [SerializeField]
    private Dropdown objectActionOptionDropdown0;

    [SerializeField]
    private Dropdown objectConditionDropdown1;
    [SerializeField]
    private Dropdown objectConditionOptionDropdown1;
    [SerializeField]
    private Dropdown conditionDropdown1;
    [SerializeField]
    private Dropdown conditionOptionDropdown1;
    [SerializeField]
    private Dropdown actionDropdown1;
    [SerializeField]
    private Dropdown actionOptionDropdown1;
    [SerializeField]
    private Dropdown objectActionDropdown1;
    [SerializeField]
    private Dropdown objectActionOptionDropdown1;

    [SerializeField]
    private Dropdown objectConditionDropdown2;
    [SerializeField]
    private Dropdown objectConditionOptionDropdown2;
    [SerializeField]
    private Dropdown conditionDropdown2;
    [SerializeField]
    private Dropdown conditionOptionDropdown2;
    [SerializeField]
    private Dropdown actionDropdown2;
    [SerializeField]
    private Dropdown actionOptionDropdown2;
    [SerializeField]
    private Dropdown objectActionDropdown2;
    [SerializeField]
    private Dropdown objectActionOptionDropdown2;

    //populate dropdown menus with enum values
    void EnumDropdown(Dropdown dropdown, System.Enum e)
    {
        List<string> objlistnames = new List<string>();
        var objnames = System.Enum.GetNames(e.GetType());
        foreach (string i in objnames)
        {
            if (i == "None")
            {
                objlistnames.Add("-");
            }
            else
            {
                objlistnames.Add(i);
            }
        }
        dropdown.ClearOptions();
        dropdown.AddOptions(objlistnames);
    }

    private void Awake()
    {
        enumDictionary.Add(ObjectE.Self, NoneE.None);//pair enums with other enums for lookups to change option dropdown
        enumDictionary.Add(ObjectE.Enemy, ObjectOptionE.Automaton);
        enumDictionary.Add(ObjectE.Allied, ObjectOptionE.Automaton);

        enumDictionary.Add(ConditionE.Always, NoneE.None);
        enumDictionary.Add(ConditionE.LessThanHealth, PercentE.ZeroPct);
        enumDictionary.Add(ConditionE.MoreThanHealth, PercentE.ZeroPct);
        enumDictionary.Add(ConditionE.LessThanSpecial, PercentE.ZeroPct);
        enumDictionary.Add(ConditionE.MoreThanSpecial, PercentE.ZeroPct);

        enumDictionary.Add(ActionE.Move, NoneE.None);
        enumDictionary.Add(ActionE.Primary, PrimaryTypeE.Gun);
        enumDictionary.Add(ActionE.Secondary, SecondaryTypeE.Rocket);
        enumDictionary.Add(ActionE.Special, SpecialTypeE.Lightning);

        playerSelect = gameObject.GetComponent<PlayerSelect>();

        objectConditionDropdown0.onValueChanged.AddListener(delegate { DropdownValueChanged(); });
        objectConditionOptionDropdown0.onValueChanged.AddListener(delegate { DropdownValueChanged(); });
        objectConditionDropdown1.onValueChanged.AddListener(delegate { DropdownValueChanged(); });
        objectConditionOptionDropdown1.onValueChanged.AddListener(delegate { DropdownValueChanged(); });
        objectConditionDropdown2.onValueChanged.AddListener(delegate { DropdownValueChanged(); });
        objectConditionOptionDropdown2.onValueChanged.AddListener(delegate { DropdownValueChanged(); });

        conditionDropdown0.onValueChanged.AddListener(delegate { DropdownValueChanged(); });
        conditionOptionDropdown0.onValueChanged.AddListener(delegate { DropdownValueChanged(); });
        conditionDropdown1.onValueChanged.AddListener(delegate { DropdownValueChanged(); });
        conditionOptionDropdown1.onValueChanged.AddListener(delegate { DropdownValueChanged(); });
        conditionDropdown2.onValueChanged.AddListener(delegate { DropdownValueChanged(); });
        conditionOptionDropdown2.onValueChanged.AddListener(delegate { DropdownValueChanged(); });


        actionDropdown0.onValueChanged.AddListener(delegate { DropdownValueChanged(); });
        actionOptionDropdown0.onValueChanged.AddListener(delegate { DropdownValueChanged(); });
        actionDropdown1.onValueChanged.AddListener(delegate { DropdownValueChanged(); });
        actionOptionDropdown1.onValueChanged.AddListener(delegate { DropdownValueChanged(); });
        actionDropdown2.onValueChanged.AddListener(delegate { DropdownValueChanged(); });
        actionOptionDropdown2.onValueChanged.AddListener(delegate { DropdownValueChanged(); });

        objectActionDropdown0.onValueChanged.AddListener(delegate { DropdownValueChanged(); });
        objectActionOptionDropdown0.onValueChanged.AddListener(delegate { DropdownValueChanged(); });
        objectActionDropdown1.onValueChanged.AddListener(delegate { DropdownValueChanged(); });
        objectActionOptionDropdown1.onValueChanged.AddListener(delegate { DropdownValueChanged(); });
        objectActionDropdown2.onValueChanged.AddListener(delegate { DropdownValueChanged(); });
        objectActionOptionDropdown2.onValueChanged.AddListener(delegate { DropdownValueChanged(); });

        EnumDropdown(objectConditionDropdown0, ObjectE.Enemy);
        EnumDropdown(objectConditionDropdown1, ObjectE.Enemy);
        EnumDropdown(objectConditionDropdown2, ObjectE.Enemy);

        EnumDropdown(conditionDropdown0, ConditionE.Always);
        EnumDropdown(conditionDropdown1, ConditionE.Always);
        EnumDropdown(conditionDropdown2, ConditionE.Always);

        EnumDropdown(actionDropdown0, ActionE.Move);
        EnumDropdown(actionDropdown1, ActionE.Move);
        EnumDropdown(actionDropdown2, ActionE.Move);

        EnumDropdown(objectActionDropdown0, ObjectE.Enemy);
        EnumDropdown(objectActionDropdown1, ObjectE.Enemy);
        EnumDropdown(objectActionDropdown2, ObjectE.Enemy);
        
        defaultLogicMatrixEnum[0] = LogicGateEnumChange((ObjectE)objectConditionDropdown0.value, objectConditionOptionDropdown0.value, (ConditionE)conditionDropdown0.value, conditionOptionDropdown0.value, (ActionE)actionDropdown0.value, actionDropdown0.value, ObjectE.Enemy, (int)ObjectOptionE.Nearest);
        defaultLogicMatrixEnum[1] = LogicGateEnumChange((ObjectE)objectConditionDropdown1.value, objectConditionOptionDropdown1.value, (ConditionE)conditionDropdown1.value, conditionOptionDropdown1.value, (ActionE)actionDropdown1.value, actionDropdown1.value, ObjectE.Enemy, (int)ObjectOptionE.Base);
        defaultLogicMatrixEnum[2] = LogicGateEnumChange((ObjectE)objectConditionDropdown2.value, objectConditionOptionDropdown2.value, (ConditionE)conditionDropdown2.value, conditionOptionDropdown2.value, (ActionE)actionDropdown2.value, actionDropdown2.value, ObjectE.Enemy, (int)ObjectOptionE.Base);
        defaultLogicMatrixEnum[3] = LogicGateEnumChange((ObjectE)objectConditionDropdown2.value, objectConditionOptionDropdown2.value, (ConditionE)conditionDropdown2.value, conditionOptionDropdown2.value, (ActionE)actionDropdown2.value, actionDropdown2.value, ObjectE.Enemy, (int)ObjectOptionE.Base);

        logicMatrixEnum[0] = new LogicGateEnum();
        logicMatrixEnum[0] = defaultLogicMatrixEnum[0];
        logicMatrixEnum[1] = new LogicGateEnum();
        logicMatrixEnum[1] = defaultLogicMatrixEnum[1];
        logicMatrixEnum[2] = new LogicGateEnum();
        logicMatrixEnum[2] = defaultLogicMatrixEnum[2];
        logicMatrixEnum[3] = new LogicGateEnum();
        logicMatrixEnum[3] = defaultLogicMatrixEnum[3];

        SetDropdowns(logicMatrixEnum);
        Apply();
    }

    void DropdownValueChanged ()
    {
        System.Enum e;

        enumDictionary.TryGetValue((ObjectE)objectConditionDropdown0.value, out e);
        EnumDropdown(objectConditionOptionDropdown0, e);
        enumDictionary.TryGetValue((ConditionE)conditionDropdown0.value, out e);
        EnumDropdown(conditionOptionDropdown0, e);
        enumDictionary.TryGetValue((ActionE)actionDropdown0.value, out e);
        EnumDropdown(actionOptionDropdown0, e);
        enumDictionary.TryGetValue((ObjectE)objectActionDropdown0.value, out e);
        EnumDropdown(objectActionOptionDropdown0, e);

        enumDictionary.TryGetValue((ObjectE)objectConditionDropdown1.value, out e);
        EnumDropdown(objectConditionOptionDropdown1, e);
        enumDictionary.TryGetValue((ConditionE)conditionDropdown1.value, out e);
        EnumDropdown(conditionOptionDropdown1, e);
        enumDictionary.TryGetValue((ActionE)actionDropdown1.value, out e);
        EnumDropdown(actionOptionDropdown1, e);
        enumDictionary.TryGetValue((ObjectE)objectActionDropdown1.value, out e);
        EnumDropdown(objectActionOptionDropdown1, e);

        enumDictionary.TryGetValue((ObjectE)objectConditionDropdown2.value, out e);
        EnumDropdown(objectConditionOptionDropdown2, e);
        enumDictionary.TryGetValue((ConditionE)conditionDropdown2.value, out e);
        EnumDropdown(conditionOptionDropdown2, e);
        enumDictionary.TryGetValue((ActionE)actionDropdown2.value, out e);
        EnumDropdown(actionOptionDropdown2, e);
        enumDictionary.TryGetValue((ObjectE)objectActionDropdown2.value, out e);
        EnumDropdown(objectActionOptionDropdown2, e);

        if (objectConditionDropdown0.value != (int)logicMatrixEnum[0].objectCondition) { objectConditionDropdown0.captionText.color = Color.red; } else { objectConditionDropdown0.captionText.color = Color.green; }
        if (objectConditionOptionDropdown0.value != logicMatrixEnum[0].objectConditionOption) { objectConditionOptionDropdown0.captionText.color = Color.red; } else { objectConditionOptionDropdown0.captionText.color = Color.green; }
        if (conditionDropdown0.value != (int)logicMatrixEnum[0].condition) { conditionDropdown0.captionText.color = Color.red; } else { conditionDropdown0.captionText.color = Color.green; }
        if (conditionOptionDropdown0.value != logicMatrixEnum[0].conditionOption) { conditionOptionDropdown0.captionText.color = Color.red; } else { conditionOptionDropdown0.captionText.color = Color.green; }
        if (actionDropdown0.value != (int)logicMatrixEnum[0].action) { actionDropdown0.captionText.color = Color.red; } else { actionDropdown0.captionText.color = Color.green; }
        if (actionOptionDropdown0.value != logicMatrixEnum[0].actionOption) { actionOptionDropdown0.captionText.color = Color.red; } else { actionOptionDropdown0.captionText.color = Color.green; }
        if (objectActionDropdown0.value != (int)logicMatrixEnum[0].objectAction) { objectActionDropdown0.captionText.color = Color.red; } else { objectActionDropdown0.captionText.color = Color.green; }
        if (objectActionOptionDropdown0.value != logicMatrixEnum[0].objectActionOption) { objectActionOptionDropdown0.captionText.color = Color.red; } else { objectActionOptionDropdown0.captionText.color = Color.green; }

        if (objectConditionDropdown1.value != (int)logicMatrixEnum[1].objectCondition) { objectConditionDropdown1.captionText.color = Color.red; } else { objectConditionDropdown1.captionText.color = Color.green; }
        if (objectConditionOptionDropdown1.value != logicMatrixEnum[1].objectConditionOption) { objectConditionOptionDropdown1.captionText.color = Color.red; } else { objectConditionOptionDropdown1.captionText.color = Color.green; }
        if (conditionDropdown1.value != (int)logicMatrixEnum[1].condition) { conditionDropdown1.captionText.color = Color.red; } else { conditionDropdown1.captionText.color = Color.green; }
        if (conditionOptionDropdown1.value != logicMatrixEnum[1].conditionOption) { conditionOptionDropdown1.captionText.color = Color.red; } else { conditionOptionDropdown1.captionText.color = Color.green; }
        if (actionDropdown1.value != (int)logicMatrixEnum[1].action) { actionDropdown1.captionText.color = Color.red; } else { actionDropdown1.captionText.color = Color.green; }
        if (actionOptionDropdown1.value != logicMatrixEnum[1].actionOption) { actionOptionDropdown1.captionText.color = Color.red; } else { actionOptionDropdown1.captionText.color = Color.green; }
        if (objectActionDropdown1.value != (int)logicMatrixEnum[1].objectAction) { objectActionDropdown1.captionText.color = Color.red; } else { objectActionDropdown1.captionText.color = Color.green; }
        if (objectActionOptionDropdown1.value != logicMatrixEnum[1].objectActionOption) { objectActionOptionDropdown1.captionText.color = Color.red; } else { objectActionOptionDropdown1.captionText.color = Color.green; }

        if (objectConditionDropdown2.value != (int)logicMatrixEnum[2].objectCondition) { objectConditionDropdown2.captionText.color = Color.red; } else { objectConditionDropdown2.captionText.color = Color.green; }
        if (objectConditionOptionDropdown2.value != logicMatrixEnum[2].objectConditionOption) { objectConditionOptionDropdown2.captionText.color = Color.red; } else { objectConditionOptionDropdown2.captionText.color = Color.green; }
        if (conditionDropdown2.value != (int)logicMatrixEnum[2].condition) { conditionDropdown2.captionText.color = Color.red; } else { conditionDropdown2.captionText.color = Color.green; }
        if (conditionOptionDropdown2.value != logicMatrixEnum[2].conditionOption) { conditionOptionDropdown2.captionText.color = Color.red; } else { conditionOptionDropdown2.captionText.color = Color.green; }
        if (actionDropdown2.value != (int)logicMatrixEnum[2].action) { actionDropdown2.captionText.color = Color.red; } else { actionDropdown2.captionText.color = Color.green; }
        if (actionOptionDropdown2.value != logicMatrixEnum[2].actionOption) { actionOptionDropdown2.captionText.color = Color.red; } else { actionOptionDropdown2.captionText.color = Color.green; }
        if (objectActionDropdown2.value != (int)logicMatrixEnum[2].objectAction) { objectActionDropdown2.captionText.color = Color.red; } else { objectActionDropdown2.captionText.color = Color.green; }
        if (objectActionOptionDropdown2.value != logicMatrixEnum[2].objectActionOption) { objectActionOptionDropdown2.captionText.color = Color.red; } else { objectActionOptionDropdown2.captionText.color = Color.green; }

    }
    public void Copy()
    {
        copiedLogicMatrixEnum[0] = LogicGateEnumChange((ObjectE)objectConditionDropdown0.value, objectConditionOptionDropdown0.value, (ConditionE)conditionDropdown0.value, conditionOptionDropdown0.value, (ActionE)actionDropdown0.value, actionDropdown0.value, ObjectE.Enemy, (int)ObjectOptionE.Nearest);
        copiedLogicMatrixEnum[1] = LogicGateEnumChange((ObjectE)objectConditionDropdown1.value, objectConditionOptionDropdown1.value, (ConditionE)conditionDropdown1.value, conditionOptionDropdown1.value, (ActionE)actionDropdown1.value, actionDropdown1.value, ObjectE.Enemy, (int)ObjectOptionE.Base);
        copiedLogicMatrixEnum[2] = LogicGateEnumChange((ObjectE)objectConditionDropdown2.value, objectConditionOptionDropdown2.value, (ConditionE)conditionDropdown2.value, conditionOptionDropdown2.value, (ActionE)actionDropdown2.value, actionDropdown2.value, ObjectE.Enemy, (int)ObjectOptionE.Base);
    }

    public void Paste()
    {
        SetDropdowns(copiedLogicMatrixEnum);
    }

    public void Apply ()
    {
        logicMatrixEnum[0] = LogicGateEnumChange((ObjectE)objectConditionDropdown0.value, objectConditionOptionDropdown0.value, (ConditionE)conditionDropdown0.value, conditionOptionDropdown0.value, (ActionE)actionDropdown0.value, actionOptionDropdown0.value, (ObjectE)objectActionDropdown0.value, objectActionOptionDropdown0.value);
        logicMatrixEnum[1] = LogicGateEnumChange((ObjectE)objectConditionDropdown1.value, objectConditionOptionDropdown1.value, (ConditionE)conditionDropdown1.value, conditionOptionDropdown1.value, (ActionE)actionDropdown1.value, actionOptionDropdown1.value, (ObjectE)objectActionDropdown1.value, objectActionOptionDropdown1.value);
        logicMatrixEnum[2] = LogicGateEnumChange((ObjectE)objectConditionDropdown2.value, objectConditionOptionDropdown2.value, (ConditionE)conditionDropdown2.value, conditionOptionDropdown2.value, (ActionE)actionDropdown2.value, actionOptionDropdown2.value, (ObjectE)objectActionDropdown2.value, objectActionOptionDropdown2.value);
        
        if (playerSelect.selected.Count > 0)
        {
            foreach (GameObject obj in playerSelect.selected)
            {
                obj.GetComponent<Status>().logicMatrixEnum[0] = LogicGateEnumChange((ObjectE)objectConditionDropdown0.value, objectConditionOptionDropdown0.value, (ConditionE)conditionDropdown0.value, conditionOptionDropdown0.value, (ActionE)actionDropdown0.value, actionOptionDropdown0.value, (ObjectE)objectActionDropdown0.value, objectActionOptionDropdown0.value);
                obj.GetComponent<Status>().logicMatrixEnum[1] = LogicGateEnumChange((ObjectE)objectConditionDropdown1.value, objectConditionOptionDropdown1.value, (ConditionE)conditionDropdown1.value, conditionOptionDropdown1.value, (ActionE)actionDropdown1.value, actionOptionDropdown1.value, (ObjectE)objectActionDropdown1.value, objectActionOptionDropdown1.value);
                obj.GetComponent<Status>().logicMatrixEnum[2] = LogicGateEnumChange((ObjectE)objectConditionDropdown2.value, objectConditionOptionDropdown2.value, (ConditionE)conditionDropdown2.value, conditionOptionDropdown2.value, (ActionE)actionDropdown2.value, actionOptionDropdown2.value, (ObjectE)objectActionDropdown2.value, objectActionOptionDropdown2.value);
                obj.GetComponent<Status>().logicMatrixEnum[3] = logicMatrixEnum[3];
            }
        }
        SetDropdowns(logicMatrixEnum);
    }

    public void SetStored(LogicGateEnum[] matrix)
    {
        logicMatrixEnum = matrix;
    }

    public void SetDropdowns (LogicGateEnum[] matrix)
    {
        objectConditionDropdown0.value = (int)matrix[0].objectCondition;
        objectConditionOptionDropdown0.value = (int)matrix[0].objectConditionOption;
        conditionDropdown0.value = (int)matrix[0].condition;
        conditionOptionDropdown0.value = (int)matrix[0].conditionOption;
        actionDropdown0.value = (int)matrix[0].action;
        actionOptionDropdown0.value = (int)matrix[0].actionOption;
        objectActionDropdown0.value = (int)matrix[0].objectAction;
        objectActionOptionDropdown0.value = (int)matrix[0].objectActionOption;

        objectConditionDropdown1.value = (int)matrix[1].objectCondition;
        objectConditionOptionDropdown1.value = (int)matrix[1].objectConditionOption;
        conditionDropdown1.value = (int)matrix[1].condition;
        conditionOptionDropdown1.value = (int)matrix[1].conditionOption;
        actionDropdown1.value = (int)matrix[1].action;
        actionOptionDropdown1.value = (int)matrix[1].actionOption;
        objectActionDropdown1.value = (int)matrix[1].objectAction;
        objectActionOptionDropdown1.value = (int)matrix[1].objectActionOption;

        objectConditionDropdown2.value = (int)matrix[2].objectCondition;
        objectConditionOptionDropdown2.value = (int)matrix[2].objectConditionOption;
        conditionDropdown2.value = (int)matrix[2].condition;
        conditionOptionDropdown2.value = (int)matrix[2].conditionOption;
        actionDropdown2.value = (int)matrix[2].action;
        actionOptionDropdown2.value = (int)matrix[2].actionOption;
        objectActionDropdown2.value = (int)matrix[2].objectAction;
        objectActionOptionDropdown2.value = (int)matrix[2].objectActionOption;

        DropdownValueChanged();
    }

    private LogicGateEnum LogicGateEnumChange(ObjectE objectCondition, int objectConditionOption, ConditionE condition, int conditionOption, ActionE action, int actionOption, ObjectE objectAction, int objectActionOption)
    {
        LogicGateEnum logicGate = new LogicGateEnum();

        logicGate.objectCondition = objectCondition;
        logicGate.objectConditionOption = objectConditionOption;
        logicGate.condition = condition;
        logicGate.conditionOption = conditionOption;
        logicGate.action = action;
        logicGate.actionOption = actionOption;
        logicGate.objectAction = objectAction;
        logicGate.objectActionOption = objectActionOption;

        return logicGate;
    }
}
