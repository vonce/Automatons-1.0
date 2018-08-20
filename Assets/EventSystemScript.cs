using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystemScript : MonoBehaviour {

    [SerializeField]
    private float dayCycleTime;
    private float nextDayCycle;
    [SerializeField]
    private GameObject player1;
    [SerializeField]
    private GameObject player2;
    [SerializeField]
    private GameObject dayLight;
    [SerializeField]
    private GameObject nightLight;
    private GameObject[] players = new GameObject[2];
    private Player[] playerScripts = new Player[2];
    // Update is called once per frame
    private void Awake()
    {
        nextDayCycle = Mathf.Infinity;
        playerScripts[0] = player1.GetComponent<Player>();
        playerScripts[1] = player2.GetComponent<Player>();
        players[0] = player1;
        players[1] = player2;
    }

    void nextDay()
    {
        foreach (Player playerScript in playerScripts)
        {
            playerScript.done = false;
        }
        dayLight.SetActive(true);
        nightLight.SetActive(false);
        nextDayCycle = dayCycleTime + Time.time;
        foreach (GameObject player in players)
        {
            GameObject[] list = GameObject.FindGameObjectsWithTag(player.tag);
            foreach (GameObject obj in list)
            {
                if(obj.GetComponent<Status>() != null)
                {
                    obj.GetComponent<Status>().active = true;
                }
            }
        }
    }

    void night()
    {
        nextDayCycle = Mathf.Infinity;
        foreach (Player playerScript in playerScripts)
        {
            playerScript.nextNight();
        }
        dayLight.SetActive(false);
        nightLight.SetActive(true);
        foreach (GameObject player in players)
        {
            GameObject[] list = GameObject.FindGameObjectsWithTag(player.tag);
            GameObject.FindGameObjectsWithTag(player.tag);
            foreach (GameObject obj in list)
            {
                if (obj.GetComponent<Status>() != null)
                {
                    obj.GetComponent<Status>().active = false;
                }
            }
        }
    }

	void Update ()
    {
        if (playerScripts[0].done == true && playerScripts[1].done == true)
        {
            nextDay();
        }
        if (nextDayCycle <= Time.time)
        {
            night();
        }
    }
}
