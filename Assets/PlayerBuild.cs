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
    private GameObject building;
    private GameObject buildingPlaced;
    private Camera playerCamera;
    private int layermask = 1 << 12;

    // Use this for initialization
    private void Awake()
    {
        playerCamera = gameObject.GetComponent<Camera>();
    }
    void Start ()
    {
        building = factory;
	}
	
	void Update ()
    {
        RaycastHit raycasthit = new RaycastHit();
        if (Physics.Raycast(playerCamera.ScreenPointToRay(Input.mousePosition), out raycasthit, Mathf.Infinity, layermask) == true && buildingPlaced != null)
        {
            buildingPlaced.transform.position = raycasthit.point;
            buildingPlaced.transform.rotation = Quaternion.FromToRotation(buildingPlaced.transform.up, buildingPlaced.transform.position) * buildingPlaced.transform.rotation;
            buildingPlaced.tag = gameObject.tag;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(playerCamera.ScreenPointToRay(Input.mousePosition), out raycasthit, Mathf.Infinity, layermask) == true && building != null)
            {
                buildingPlaced = Instantiate(building, raycasthit.point, Quaternion.identity);
                buildingPlaced.transform.rotation = Quaternion.FromToRotation(buildingPlaced.transform.up, buildingPlaced.transform.position) * buildingPlaced.transform.rotation;
                buildingPlaced.tag = gameObject.tag;
            }
        }
        
    }
}
