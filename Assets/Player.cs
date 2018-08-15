using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Text metalText;
    [SerializeField]
    private float metalRate;
    private float nextMetal;
    public int metal;
    public GameObject myBase;
    public GameObject enemyBase;
    public bool done;
    public HashSet<GameObject> ownedObjects = new HashSet<GameObject>();
    public GameObject gameUI;
    public GameObject logicMatrixUI;
    

    private void Awake()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag(gameObject.tag))
        {
            if (obj.GetComponent<Status>() != null)
            {
                ownedObjects.Add(obj);
            }
        }
        nextMetal = metalRate + Time.time;
    }

    public void editLogicMatrixUI()
    {
        GetComponent<PlayerBuild>().isBuilding = false;
        gameUI.SetActive(false);
        logicMatrixUI.SetActive(true);
        if (GetComponent<PlayerSelect>().selected.Count > 0)
        {
            Status objStatus = GetComponent<PlayerSelect>().selected[0].GetComponent<Status>();
            GetComponent<PlayerLogicHandler>().SetStored(objStatus.logicMatrixEnum);
            GetComponent<PlayerLogicHandler>().SetDropdowns(objStatus.logicMatrixEnum);
        }
    }
    public void backToGameUI()
    {
        gameUI.SetActive(true);
        logicMatrixUI.SetActive(false);
    }

    private void Start()
    {
        metalChange(0);
    }

    public void metalChange(int m)
    {
        metal += m;
        metalText.text = "METAL: " + metal.ToString();
    }

    public void nextDay()
    {
        GetComponent<PlayerBuild>().isBuilding = false;
        gameUI.SetActive(false);
        done = true;
    }

    public void nextNight()
    {
        gameUI.SetActive(true);
        done = false;
    }

    private void FixedUpdate()
    {
        if (nextMetal <= Time.time)
        {
            foreach (GameObject obj in ownedObjects)
            {
                if (obj != null && obj.GetComponent<Status>().active == true && (obj.GetComponent<Status>().unitType == UnitTypeE.Refinery || obj.GetComponent<Status>().unitType == UnitTypeE.Base))
                {
                    metalChange(1);
                }
            }
            nextMetal = metalRate + Time.time;
        }
    }
}
