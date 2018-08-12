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
    private int metal = 100;
    public GameObject myBase;
    public GameObject enemyBase;
    public bool done;
    private List<GameObject> selected = new List<GameObject>();
    public HashSet<GameObject> ownedObjects = new HashSet<GameObject>();
    [SerializeField]
    private GameObject gameUI;
    [SerializeField]
    private GameObject logicMatrixUI;
    

    private void Awake()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag(gameObject.tag))
        {
            if (obj.name != "Player")
            {
                ownedObjects.Add(obj);
            }
        }
        nextMetal = metalRate + Time.time;
    }

    public void editLogicMatrixUI()
    {
        gameUI.SetActive(false);
        logicMatrixUI.SetActive(true);
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
        gameUI.SetActive(false);
        done = true;
    }

    public void nextNight()
    {
        gameUI.SetActive(true);
        done = false;
    }

    private void Update()
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
