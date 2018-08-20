using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHeal : MonoBehaviour
{
    Status status;
    [SerializeField]
    float healRate;
    [SerializeField]
    int healAmount;
    float nextHeal;
    // Use this for initialization
    void Start ()
    {
        status = GetComponent<Status>();
        nextHeal = healRate + Time.time;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (nextHeal <= Time.time)
        {
            foreach (GameObject obj in status.inSightRange)
            {
                if (obj != null && obj.GetComponent<Status>() != null)
                {
                    obj.GetComponent<Status>().HealthChange(healAmount);
                }
            }
            nextHeal = healRate + Time.time;
        }
	}
}
