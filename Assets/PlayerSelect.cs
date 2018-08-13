using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelect : MonoBehaviour
{
    [SerializeField]
    private Image highlight;
    private Vector3 startpos;
    private Vector3 endpos;
    private Vector3 startposViewport;
    private Vector3 endposViewport;
    private int buildingLayerMask = 1 << 10;
    private HashSet<GameObject> selected = new HashSet<GameObject>();
    private Player player;
    private Camera playerCamera;
    [SerializeField]
    private Text SelectedText;

    private void Start()
    {
        player = GetComponent<Player>();
        playerCamera = GetComponent<Camera>();
    }
    // Update is called once per frame
    void Update ()
    {
        if (Input.GetMouseButtonDown(0) && player.GetComponent<PlayerBuild>().isBuilding == false)
        {
            highlight.gameObject.SetActive(true);
            selected.Clear();
            RaycastHit raycasthit;
            startpos = Input.mousePosition;
            startposViewport = playerCamera.ScreenToViewportPoint(Input.mousePosition);
            if (Physics.Raycast(playerCamera.ScreenPointToRay(Input.mousePosition), out raycasthit, Mathf.Infinity, buildingLayerMask) == true)
            {
                if (raycasthit.collider.transform.parent.gameObject.tag == gameObject.tag && raycasthit.collider.GetComponentInParent<Status>().unitType == UnitTypeE.Factory)
                {
                    selected.Add(raycasthit.collider.transform.parent.gameObject);
                }
            }
        }
        if (Input.GetMouseButtonUp(0) && player.GetComponent<PlayerBuild>().isBuilding == false)
        {
            highlight.gameObject.SetActive(false);
            HashSet<GameObject> selected = new HashSet<GameObject>();
            endposViewport = playerCamera.ScreenToViewportPoint(Input.mousePosition);
            Rect selectRect = new Rect(startposViewport.x, startposViewport.y, endposViewport.x - startposViewport.x, endposViewport.y - startposViewport.y);
            foreach (GameObject obj in player.ownedObjects)
            {
                if (obj != null)
                {
                    if (selectRect.Contains(playerCamera.WorldToViewportPoint(obj.transform.position), true) && obj.GetComponent<Status>().unitType == UnitTypeE.Factory)
                    {
                        selected.Add(obj);
                    }
                }
            }
            SelectedText.text = "Selected: " + selected.Count.ToString();
        }

        if (Input.GetMouseButton(0) && player.GetComponent<PlayerBuild>().isBuilding == false)
        {
            if (highlight.gameObject.activeInHierarchy == false)
            {
                highlight.gameObject.SetActive(true);
            }
            endpos = Input.mousePosition;
            float sizeX = Mathf.Abs(startpos.x - endpos.x);
            float sizeY = Mathf.Abs(startpos.y - endpos.y);
            highlight.rectTransform.position = playerCamera.ScreenToWorldPoint((new Vector3(startpos.x, startpos.y, 10) + new Vector3(endpos.x, endpos.y, 10)) / 2);
            highlight.rectTransform.sizeDelta = new Vector2(sizeX, sizeY);
        }
    }
}
