using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    private Status status;
    private UnitBrain unitBrain;
    private Vector3 targetVector;
    private Vector3 moveDirection;
    private float targetDistance;
    [SerializeField]
    private GameObject turretHead;
    [SerializeField]
    private Rigidbody bulletPrefab;
    private Rigidbody bullet;
    [SerializeField]
    private GameObject gun;
    [SerializeField]
    private GameObject missileLauncher;
    [SerializeField]
    private float gunFireRate;
    private float nextGunFire;
    private GameObject objCheck;
    private List<GameObject> list = new List<GameObject>();

    // Use this for initialization
    void Start () {
        status = GetComponent<Status>();
        unitBrain = GetComponent<UnitBrain>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (status.target != null)
        {
            targetVector = transform.position - status.target.transform.position;
            targetDistance = Vector3.Distance(status.target.transform.position, transform.position);

            if (status.attackRange < targetDistance)
            {
                RotateToTarget();
            }
            if (status.attackRange >= targetDistance && Time.time > nextGunFire && status.primaryType == PrimaryTypeE.Gun)//Gun attack
            {
                bullet = Instantiate(bulletPrefab, gun.transform.position, Quaternion.LookRotation(targetVector));
                bullet.tag = gameObject.tag;
                bullet.GetComponent<Bullet>().attackPower = status.attackPower;
                bullet.AddForce(-targetVector.normalized * 1000, ForceMode.Force);

                nextGunFire = gunFireRate + Time.time;
            }
        }
        if (nextGunFire < Time.time)
        {
            if (status.inSightRange.Count > 0)
            {
                list = new List<GameObject>(status.inSightRange);
                foreach (GameObject obj in status.inSightRange)
                {
                    if (obj != null && obj.tag == gameObject.tag)
                    {
                        list.Remove(obj);
                    }
                }
                if (list.Count > 0)
                {
                    objCheck = list[0];
                    foreach (GameObject obj in list)
                    {
                        if (objCheck != null && obj != null && Vector3.Distance(gameObject.transform.position, obj.transform.position) < Vector3.Distance(gameObject.transform.position, objCheck.transform.position))
                        {
                            objCheck = obj;
                            Debug.Log(objCheck);
                        }
                    }
                    if (objCheck != gameObject)
                    {
                        status.target = objCheck;
                    }
                }
            }
            nextGunFire = gunFireRate + Time.time;
        }
    }

    private void RotateToTarget()
    {
        if (status.target != null)
        {
            moveDirection = Vector3.ProjectOnPlane(transform.position - status.target.transform.position, transform.up);
            //turretHead.transform.rotation = Quaternion.LookRotation( moveDirection, transform.right);
        }
    }
}
