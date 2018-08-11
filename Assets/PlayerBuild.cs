using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBuild : MonoBehaviour {

    [SerializeField]
    private GameObject factory;
    [SerializeField]
    private GameObject refinery;
    [SerializeField]
    private GameObject silo;
    [SerializeField]
    private bool isBuilding = false;
    private bool buildable = false;
    private GameObject buildableArea;
    private GameObject building;
    [SerializeField]
    private GameObject buildingPreview;
    private Camera playerCamera;
    private int moonLayermask = 1 << 12;
    private Player player;
    public HashSet<GameObject> ownedObjects = new HashSet<GameObject>();

    // Use this for initialization
    private void Awake()
    {
        player = GetComponent<Player>();
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag(gameObject.tag))
        {
            if (obj.name != "Player")
            {
                ownedObjects.Add(obj);
            }
        }
        playerCamera = gameObject.GetComponent<Camera>();
    }
    void Start ()
    {
        building = factory;
	}

    public void Build()
    {
        isBuilding = true;
        foreach (GameObject obj in ownedObjects)
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
                    script.enabled = false;
                }
                buildingPreview.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
                buildingPreview.transform.Find("Collider").GetComponent<Collider>().isTrigger = true;
                buildingPreview.transform.rotation = Quaternion.FromToRotation(buildingPreview.transform.up, buildingPreview.transform.position) * buildingPreview.transform.rotation;
            }
        }

        if (Input.GetMouseButton(0) && isBuilding == true)
        {
            RaycastHit raycasthit = new RaycastHit();
            if (Physics.Raycast(playerCamera.ScreenPointToRay(Input.mousePosition), out raycasthit, Mathf.Infinity, moonLayermask) == true && buildingPreview != null)
            {
                buildingPreview.transform.position = raycasthit.point;
                buildingPreview.transform.rotation = Quaternion.FromToRotation(buildingPreview.transform.up, buildingPreview.transform.position) * buildingPreview.transform.rotation;
            }
            if (buildingPreview != null && buildingPreview.GetComponent<Status>().buildable == true)
            {
                buildingPreview.GetComponentInChildren<MeshRenderer>().material.color = Color.green;
            }
            else
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
                ownedObjects.Add(buildingPreview);
                buildingPreview = null;
                isBuilding = false;
                foreach (GameObject obj in ownedObjects)
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
                    foreach (GameObject obj in ownedObjects)
                    {
                        buildableArea = obj.transform.Find("Buildable").gameObject;
                        buildableArea.SetActive(false);
                    }
                }
            }
            
        }
    }
}
