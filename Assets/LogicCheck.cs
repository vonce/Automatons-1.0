using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicCheck : MonoBehaviour {

    public HashSet<GameObject> automatons = new HashSet<GameObject>();
    [SerializeField]
    private float checkRate;
    private float nextCheck;

    private void Start()
    {
        nextCheck = checkRate + Time.time;
    }
    // Update is called once per frame
    void Update ()
    {
        if (nextCheck < Time.time)
        {
            if (automatons.Count > 0)
            {
                HashSet<GameObject> tempAutomatons = new HashSet<GameObject>(automatons);
                int sleepTime = 1000 * (int)(checkRate / (float)automatons.Count);
                foreach (GameObject obj in tempAutomatons)
                {
                    if (obj != null)
                    {
                        obj.GetComponent<UnitBrain>().CheckLogicMatrix();
                        System.Threading.Thread.Sleep(sleepTime);
                    }
                    else
                    {
                        automatons.Remove(obj);
                    }
                }
            }
        }
	}
}
