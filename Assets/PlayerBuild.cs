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
            if (obj != null && obj.transform.Find("Buildable").gameObject != null)
            {
                buildableArea = obj.transform.Find("Buildable").gameObject;
                buildableArea.SetActive(true);
            }
        }
    }

    void Update ()
    {
        if (Input.GetMouseButtonDown(0) && isBuilding == true)
        {
            RaycastHit raycasthit = new RaycastHit();
            if (Physics.Raycast(playerCamera.ScreenPointToRay(Input.mousePosition), out raycasthit, Mathf.Infinity, moonLayermask) == true)
            {
                buildingPreview = Instantiate(building, raycasthit.point, Quaternion.identity);
                buildingPreview.tag = gameObject.tag;
                foreach (MonoBehaviour script in buildingPreview.GetComponents<MonoBehaviour>())
                {
                    if (script != buildingPreview.GetComponent<Status>())
                    {
                        script.enabled = false;
                    }
                }
                buildingPreview.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
                buildingPreview.transform.Find("Collider").GetComponent<Collider>().isTrigger = true;
                buildingPreview.transform.rotation = Quaternion.LookRotation(-Vector3.ProjectOnPlane(player.myBase.transform.position - buildingPreview.transform.position, buildingPreview.transform.position), buildingPreview.transform.position);
            }
        }

        if (Input.GetMouseButton(0) && isBuilding == true)
        {
            RaycastHit raycasthit = new RaycastHit();
            if (Physics.Raycast(playerCamera.ScreenPointToRay(Input.mousePosition), out raycasthit, Mathf.Infinity, moonLayermask) == true && buildingPreview != null)
            {
                buildingPreview.transform.position = raycasthit.point;
                buildingPreview.transform.rotation = Quaternion.LookRotation(-Vector3.ProjectOnPlane(player.myBase.transform.position - buildingPreview.transform.position, buildingPreview.transform.position), buildingPreview.transform.position);
            }
            if (buildingPreview != null && buildingPreview.GetComponent<Status>().buildable == true)
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
            if (buildingPreview != null && buildingPreview.GetComponent<Status>().buildable == true)
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
                    buildableArea = obj.transform.Find("Buildable").gameObject;
                    buildableArea.SetActive(false);
                }
            }
            else
            {
                if (buildingPreview != null && buildingPreview.GetComponent<Status>().buildable == false)
                {
                    Destroy(buildingPreview);
                    isBuilding = false;
                    foreach (GameObject obj in player.ownedObjects)
                    {
                        buildableArea = obj.transform.Find("Buildable").gameObject;
                        buildableArea.SetActive(false);
                    }
                }
            }
            
        }
    }
}
