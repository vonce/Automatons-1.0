using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special : MonoBehaviour, IAction
{
    private Status status;
    private UnitBrain unitBrain;

    private Vector3 targetVector;//weapon to target
    private float targetDistance;

    [SerializeField]
    private GameObject lightningPrefab;
    private GameObject lightning;

    [SerializeField]
    private float specialFireRate;
    private float nextSpecialFire;

    public ActionE enumID()
    {
        return ActionE.Special;
    }
    void Awake()
    {
        nextSpecialFire = specialFireRate + Time.time;
        status = GetComponent<Status>();
        unitBrain = GetComponent<UnitBrain>();
    }

    public bool ActionCheck(GameObject target, int option)
    {
        if (target != null && nextSpecialFire <= Time.time && status.currentSpecial >= 5)
        {
            status.specialType = (SpecialTypeE)option;
            return true;
        }
        else
        {
            return false;
        }
    }
    public void Action(GameObject target, int option)
    {
        if (target != null)
        {
            targetVector = transform.position - status.target.transform.position;
            targetDistance = Vector3.Distance(status.target.transform.position, transform.position);

            if (status.attackRange / 2 < targetDistance && status.specialType == SpecialTypeE.Lightning)//move to target if out of range
            {
                unitBrain.MoveToTarget();
            }
            else
            {
                unitBrain.RotateToTarget();
            }
            if (status.attackRange / 2 >= targetDistance && Time.time > nextSpecialFire && status.specialType == SpecialTypeE.Lightning && status.currentSpecial >= 5)//Gun attack
            {
                status.SpecialChange(-5);
                lightning = Instantiate(lightningPrefab, target.transform.position, Quaternion.identity);
                lightning.GetComponent<Lightning>().target = target;
                lightning.GetComponent<Lightning>().parent = gameObject;
                lightning.GetComponent<Lightning>().attackPower = status.attackPower;

                nextSpecialFire = specialFireRate + Time.time;
            }

            /*if (status.attackRange / 2 < targetDistance && status.primaryType == PrimaryTypeE.Beam)//move to target if out of range
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
            if (status.attackRange * 1.5 < targetDistance && status.primaryType == PrimaryTypeE.Grenade)//move to target if out of range
            {
                unitBrain.MoveToTarget();
            }
            else
            {
                unitBrain.RotateToTarget();
            }
            if (status.attackRange * 1.5 >= targetDistance && Time.time > nextGrenadeFire && status.primaryType == PrimaryTypeE.Grenade)//Grenade attack
            {
                targetVector = -(gameObject.transform.position - status.target.transform.position);
                grenade = Instantiate(grenadePrefab, weapon.transform.position, Quaternion.LookRotation(targetVector));
                grenade.tag = gameObject.tag;
                grenade.velocity = targetVector / 2;
                grenade.velocity += status.transform.up * 10;

                nextGrenadeFire = grenadeFireRate + Time.time;
            }*/
        }
    }
    void Update()
    {
        /*if (beam != null && gameObject != null && status.target != null)
        {
            beam.position = weapon.transform.position;
            beam.rotation = Quaternion.LookRotation(-(targetVector));
        }
        else
        {
            Destroy(beam);
        }*/
    }
}
