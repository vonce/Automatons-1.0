using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handles health, special, status effects.

public class Status : StatusHandler
{
    public bool active = false;
    public LogicGateEnum[] LogicMatrixEnum = new LogicGateEnum[6];
    public LogicGate[] logicMatrix = new LogicGate[6];
    public IAction action; //action gameObject is taking
    public GameObject target; //target of gameObject
    public List<GameObject> inSightRange = new List<GameObject>();//list of objects in sight range
    //private List<GameObject> inAttackRange = new List<GameObject>();//list of objects in attack range
    public PrimaryTypeE primaryType;//primary weapon type
    public SecondaryTypeE secondaryType;//secondary weapon type
    public SpecialTypeE specialType;//special type
    public HashSet<StatusE> statusEffects;//hashset of status effects
    public bool buildable = false;//used for knowing buildable areas
    [SerializeField]
    private Material blue;
    [SerializeField]
    private Material red;
    [SerializeField]
    private Material green;

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
