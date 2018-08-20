using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBuild : MonoBehaviour {

    [SerializeField]
    private GameObject factoryPrefab;
    [SerializeField]
    private GameObject refineryPrefab;
    [SerializeField]
    private GameObject emitterPrefab;
    [SerializeField]
    private GameObject turretPrefab;
    public bool isBuilding = false;
    private GameObject buildableArea;
    private GameObject building;
    [SerializeField]
    private GameObject buildingPreview;
    private Player player;
    private Camera playerCamera;
    private int moonLayermask = 1 << 12;

    // Use this for initialization
    private void Awake()
    {
        player = gameObject.GetComponent<Player>();
        playerCamera = gameObject.GetComponent<Camera>();
    }
    void Start ()
    {
        
	}

    public void BuildFactory()
    {
        building = factoryPrefab;
    }
    public void BuildRefinery()
    {
        building = refineryPrefab;
    }
    public void BuildEmitter()
    {
        building = emitterPrefab;
    }
    public void BuildTurret()
    {
        building = turretPrefab;
    }

    public void Build()
    {
        isBuilding = true;
        foreach (GameObject obj in player.ownedObjects)
        {
            if (obj != null && obj.transform.GetChild(3).GetComponent<TriggerBuildable>() == true)
            {
                obj.transform.GetChild(3).gameObject.SetActive(true);
            }
        }
    }

    void Update ()
    {
        if (Input.GetMouseButtonDown(0) && isBuilding == true)
        {
            RaycastHit raycasthit = new RaycastHit();
            if (Physics.Raycast(playerCamera.ScreenPointToRay(Input.mousePosition), out raycasthit, Mathf.Infinity, moonLayermask) == true 
                && (int)building.GetComponent<Status>().buildingCost <= player.metal)
            {
                buildingPreview = Instantiate(building, raycasthit.point, Quaternion.LookRotation(-Vector3.ProjectOnPlane(player.enemyBase.transform.position + raycasthit.point, raycasthit.point), raycasthit.point));
                buildingPreview.GetComponent<Status>().buildable = 0;
                buildingPreview.GetComponent<Status>().enemyBase = player.enemyBase;
                buildingPreview.GetComponent<Status>().allyBase = player.allyBase;
                buildingPreview.tag = gameObject.tag;
                buildingPreview.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
                buildingPreview.transform.Find("Collider").GetComponent<Collider>().isTrigger = true;
                //buildingPreview.transform.rotation = Quaternion.LookRotation(-Vector3.ProjectOnPlane(player.myBase.transform.position - buildingPreview.transform.position, buildingPreview.transform.position), buildingPreview.transform.position);
                buildingPreview.GetComponent<Status>().logicMatrixEnum = GetComponent<PlayerLogicHandler>().defaultLogicMatrixEnum;
                foreach (MonoBehaviour script in buildingPreview.GetComponents<MonoBehaviour>())
                {
                    if (script != buildingPreview.GetComponent<Status>())
                    {
                        script.enabled = false;
                    }
                }
            }
        }

        if (Input.GetMouseButton(0) && isBuilding == true)
        {
            RaycastHit raycasthit = new RaycastHit();
            if (Physics.Raycast(playerCamera.ScreenPointToRay(Input.mousePosition), out raycasthit, Mathf.Infinity, moonLayermask) == true && buildingPreview != null)
            {
                buildingPreview.transform.position = raycasthit.point;
                buildingPreview.transform.rotation = Quaternion.LookRotation(-Vector3.ProjectOnPlane(player.enemyBase.transform.position + buildingPreview.transform.position, buildingPreview.transform.position), buildingPreview.transform.position);
            }
            if (buildingPreview != null && buildingPreview.GetComponent<Status>().buildable > 0 && buildingPreview.GetComponent<Status>().colliding == 0)
            {
                buildingPreview.GetComponentInChildren<MeshRenderer>().material.color = Color.green;
            }
            else if (buildingPreview != null)
            {
                buildingPreview.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (buildingPreview != null && buildingPreview.GetComponent<Status>().buildable > 0 && buildingPreview.GetComponent<Status>().colliding == 0)
            {
                buildingPreview.GetComponentInChildren<MeshRenderer>().material.color = Color.white;
                buildingPreview.transform.Find("Collider").GetComponent<Collider>().isTrigger = false;
                foreach (MonoBehaviour script in buildingPreview.GetComponents<MonoBehaviour>())
                {
                    script.enabled = true;
                }
                player.ownedObjects.Add(buildingPreview);
                buildingPreview = null;
                isBuilding = false;
                foreach (GameObject obj in player.ownedObjects)
                {
                    if (obj.GetComponentInChildren<TriggerBuildable>() != null)
                    {
                        obj.GetComponentInChildren<TriggerBuildable>().gameObject.SetActive(false);
                    }
                }
                player.metalChange(-building.GetComponent<Status>().buildingCost);
            }
            else
            {
                if (buildingPreview != null)
                {
                    Destroy(buildingPreview);
                    isBuilding = false;
                    foreach (GameObject obj in player.ownedObjects)
                    {
                        if (obj.GetComponentInChildren<TriggerBuildable>() != null)
                        {
                            obj.GetComponentInChildren<TriggerBuildable>().gameObject.SetActive(false);
                        }
                    }
                }
            }
            
        }
    }
}
