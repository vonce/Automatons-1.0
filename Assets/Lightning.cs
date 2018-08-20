using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    private HashSet<GameObject> targets = new HashSet<GameObject>();
    [SerializeField]
    private int damage;
    [SerializeField]
    private GameObject[] lightningArc = new GameObject[10];
    private GameObject previousTarget;
    public GameObject parent;
    public GameObject target;
    public int attackPower;

    void Start ()
    {
        int i = 0;
        damage += attackPower;
        lightningArc[i].SetActive(true);
        lightningArc[i].transform.position = parent.transform.position + parent.transform.position.normalized;
        lightningArc[i].transform.rotation = Quaternion.LookRotation(-(parent.transform.position - target.transform.position), parent.transform.position);
        lightningArc[i].transform.localScale = new Vector3(1, 1, Vector3.Magnitude(parent.transform.position - target.transform.position));
        target.GetComponent<Status>().HealthChange(-damage);
        damage--;
        previousTarget = target;
        foreach (GameObject obj in targets)
        {
            i++;
            if (damage > 0)
            {
                if (obj != target && obj != gameObject)
                {
                    lightningArc[i].SetActive(true);
                    lightningArc[i].transform.position = previousTarget.transform.position + previousTarget.transform.position.normalized;
                    lightningArc[i].transform.rotation = Quaternion.LookRotation(-(previousTarget.transform.position - obj.transform.position), previousTarget.transform.position);
                    lightningArc[i].transform.localScale = new Vector3(1, 1, Vector3.Magnitude(previousTarget.transform.position - obj.transform.position));
                    obj.GetComponent<Status>().HealthChange(-damage);
                    previousTarget = obj;
                    damage--;
                }
            }
        }
	}
	
	void Update ()
    {
        /*if (targets.Count > 0)
        {
            foreach (GameObject obj in targets)
            {
                damage--;
                if (damage > 0)
                {
                    if (previousTarget != null)
                    {
                        lightningArc.transform.position = previousTarget.transform.position;
                        lightningArc.transform.rotation = Quaternion.LookRotation(previousTarget.transform.position + obj.transform.position, previousTarget.transform.position);
                    }
                    obj.GetComponent<Status>().HealthChange(-damage);
                    previousTarget = obj;
                }
            }
            targets.Clear();
        }*/
        Destroy(gameObject, .2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        targets.Add(other.transform.parent.gameObject);
    }
}
