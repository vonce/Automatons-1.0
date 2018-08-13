using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Primary : MonoBehaviour, IAction
{
    [SerializeField]
    private Rigidbody bulletPrefab;
    [SerializeField]
    private Rigidbody beamPrefab;
    [SerializeField]
    private Rigidbody grenadePrefab;
    private Rigidbody bullet;
    private Rigidbody grenade;
    private Rigidbody beam;

    [SerializeField]
    private float gunFireRate;
    [SerializeField]
    private float beamTickRate;
    [SerializeField]
    private float grenadeFireRate;

    private float nextGunFire;
    private float nextGrenadeFire;

    [SerializeField]
    private GameObject weapon;

    private Status status;
    private UnitBrain unitBrain;
    private Vector3 targetVector;//weapon to target
    public float targetDistance;

    public ActionE enumID()
    {
        return ActionE.Primary;
    }
    void Awake()
    {
        status = GetComponent<Status>();
        unitBrain = GetComponent<UnitBrain>();
    }

    public bool ActionCheck(GameObject target)
    {
        if (target != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void Action(GameObject target)
    {
        if (target != null)
        {
            targetVector = transform.position - status.target.transform.position;
            targetDistance = Vector3.Distance(status.target.transform.position, transform.position);
            
            if (status.attackRange < targetDistance && status.primaryType == PrimaryTypeE.Gun)//move to target if out of range
            {
                unitBrain.MoveToTarget();
            }
            else
            {
                unitBrain.RotateToTarget();
            }
            if (status.attackRange >= targetDistance && Time.time > nextGunFire && status.primaryType == PrimaryTypeE.Gun)//Gun attack
            {
                bullet = Instantiate(bulletPrefab, weapon.transform.position, Quaternion.LookRotation(targetVector));
                bullet.tag = gameObject.tag;
                bullet.GetComponent<Bullet>().attackPower = status.attackPower;
                bullet.AddForce(-targetVector.normalized * 1000, ForceMode.Force);

                nextGunFire = gunFireRate + Time.time;
            }

            if (status.attackRange / 2 < targetDistance && status.primaryType == PrimaryTypeE.Beam)//move to target if out of range
            {
                unitBrain.MoveToTarget();
            }
            else
            {
                unitBrain.RotateToTarget();
            }
            if (status.attackRange / 2 >= targetDistance && status.primaryType == PrimaryTypeE.Beam && beam == null)//Beam attack
            {
                {
                    beam = Instantiate(beamPrefab, weapon.transform.position, Quaternion.LookRotation(-targetVector));
                    beam.tag = gameObject.tag;
                    beam.GetComponent<Beam>().parentUnit = gameObject;
                    beam.GetComponent<Beam>().target = status.target;
                    beam.GetComponent<Beam>().tick = beamTickRate;
                }
            }
            if (status.attackRange * 2 < targetDistance && status.primaryType == PrimaryTypeE.Grenade)//move to target if out of range
            {
                unitBrain.MoveToTarget();
            }
            else
            {
                unitBrain.RotateToTarget();
            }
            if (status.attackRange * 2 >= targetDistance && Time.time > nextGrenadeFire && status.primaryType == PrimaryTypeE.Grenade)//Grenade attack
            {
                targetVector = -(gameObject.transform.position - status.target.transform.position);
                grenade = Instantiate(grenadePrefab, weapon.transform.position, Quaternion.LookRotation(targetVector));
                grenade.tag = gameObject.tag;
                grenade.velocity = targetVector/2;
                grenade.velocity += status.transform.up * 10;

                nextGrenadeFire = grenadeFireRate + Time.time;
            }
        }
    }
    void Update()
    {
        if (beam != null && gameObject != null && status.target != null)
        {
            beam.position = weapon.transform.position;
            beam.rotation = Quaternion.LookRotation(-(targetVector));
        }
        else
        {
            Destroy(beam);
        }
    }
}

