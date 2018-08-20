using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handles health, special, status effects.

public class Status : StatusHandler
{
    public int buildable;//used for knowing buildable areas
    public int colliding;//" "
    public bool selected = false;
    public LogicGateEnum[] logicMatrixEnum = new LogicGateEnum[4];
    public LogicGate[] logicMatrix = new LogicGate[4];
    public IAction action; //action gameObject is taking
    public GameObject target; //target of gameObject
    public GameObject enemyBase;//enemyBase
    public GameObject allyBase;//enemyBase
    public HashSet<GameObject> inSightRange = new HashSet<GameObject>();//list of objects in sight range
    public int buildingCost;//building cost
    public UnitTypeE unitType;//unit type
    public PrimaryTypeE primaryType;//primary weapon type
    public SecondaryTypeE secondaryType;//secondary weapon type
    public SpecialTypeE specialType;//special type
    public HashSet<StatusE> statusEffects;//hashset of status effects on unit
    [SerializeField]
    private Material blue;
    [SerializeField]
    private Material red;
    [SerializeField]
    private Material green;

    void Awake()
    {
        GameObject[] gameObjArr = GameObject.FindGameObjectsWithTag(gameObject.tag);
        foreach (GameObject obj in gameObjArr)
        {
            if (unitType != UnitTypeE.Base && obj.GetComponent<Status>() != null && obj.GetComponent<Status>().unitType == UnitTypeE.Base)
            {
                enemyBase = obj.GetComponent<Status>().enemyBase;
                allyBase = obj;
            }
        }
    }
    private void Start()
    {
    Component[] meshes = GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer mesh in meshes)
        {
            if (gameObject.tag == "Blue")
            {
                mesh.material = blue;
            }
            if (gameObject.tag == "Red")
            {
                mesh.material = red;
            }
            if (gameObject.tag == "Green")
            {
                mesh.material = green;
            }
        }
    }
}
