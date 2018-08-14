using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handles health, special, status effects.

public class Status : StatusHandler
{
    public bool buildable = false;//used for knowing buildable areas
    public bool colliding = false;//" "
    public bool selected = false;
    public LogicGateEnum[] logicMatrixEnum = new LogicGateEnum[6];
    public LogicGate[] logicMatrix = new LogicGate[6];
    public IAction action; //action gameObject is taking
    public GameObject target; //target of gameObject
    public GameObject enemyBase;//enemyBase
    public List<GameObject> inSightRange = new List<GameObject>();//list of objects in sight range
    public List<GameObject> filteredInSightRange = new List<GameObject>();//list of objects that satisfy object filters
    //private List<GameObject> inAttackRange = new List<GameObject>();//list of objects in attack range
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

    void Start()
    {
        GameObject[] gameObjArr = GameObject.FindGameObjectsWithTag(gameObject.tag);
        foreach (GameObject obj in gameObjArr)
        {
            if (unitType != UnitTypeE.Base && obj.GetComponent<Status>() != null && obj.GetComponent<Status>().unitType == UnitTypeE.Base)
            {
                //Debug.Log(obj);
                enemyBase = obj.GetComponent<Status>().enemyBase;
            }
        }

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
