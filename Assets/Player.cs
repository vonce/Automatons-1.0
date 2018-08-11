using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Text metalText;
    private int metal = 50;
    public bool done;
    private List<GameObject> selected = new List<GameObject>();
    [SerializeField]
    private GameObject gameUI;
    [SerializeField]
    private GameObject logicMatrixUI;
    
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
}
