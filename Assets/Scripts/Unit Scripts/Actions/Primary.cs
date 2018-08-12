using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Primary : MonoBehaviour, IAction
{
    [SerializeField]
    private Rigidbody BulletPrefab;
    [SerializeField]
    private Rigidbody BeamPrefab;
    [SerializeField]
    private Rigidbody GrenadePrefab;
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
    private float nextBeamTick;
    private float nextGrenadeFire;

    [SerializeField]
    private GameObject weapon;

    private Status status;
    private UnitBrain unitBrain;
    private Vector3 bulletVector;
    private Vector3 grenadeVector;
    private Vector3 beamVector;
    private float vectorMag;
    private float targetDistance;

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
            targetDistance = Vector3.Distance(status.target.transform.position, transform.position);
            
            if (status.attackRange < targetDistance)
            {
                unitBrain.MoveToTarget();
            }
            else
            {
                unitBrain.RotateToTarget();
            }
            /*if (status.attackRange >= targetDistance && Time.time > nextFire && status.primaryType == PrimaryTypeE.Grenade)//Grenade attack
            {
                grenadeVector = -(gameObject.transform.position - status.target.transform.position) / 2;
                grenadeVector += new Vector3(0, 9, 0);
                grenade = Instantiate(GrenadePrefab, Front.position, Front.rotation) as Rigidbody;
                grenade.velocity = grenadeVector;

                nextFire = Time.time + (fireRate) * 2;
            }*/

            if (status.attackRange >= targetDistance && Time.time > nextGunFire && status.primaryType == PrimaryTypeE.Gun)//Gun attack
            {
                bulletVector = gameObject.transform.position - status.target.transform.position;
                bullet = Instantiate(BulletPrefab, weapon.transform.position, Quaternion.LookRotation(bulletVector));
                bullet.tag = gameObject.tag;
                bullet.GetComponent<Bullet>().parentUnit = gameObject;
                bullet.AddForce(-bulletVector.normalized * 500, ForceMode.Force);

                nextGunFire = Time.time + gunFireRate;
            }

            /*if (status.attackRange >= targetDistance && Time.time > nextFire && status.attackType == AttackTypeE.Beam)//Beam attack
            {
                beamVector = gameObject.transform.position - status.target.transform.position;
                if (beam == null)
                {
                    beam = Instantiate(BeamPrefab, Front.position, Quaternion.LookRotation(-beamVector)) as Rigidbody;
                }
            }*/
        }
    }
    void Update()
    {
        /*if (beam != null && gameObject != null && status.target != null && transform.position - status.target.transform.position != new Vector3(0, 0, 0))
        {
            beam.position = Front.position;
            beam.rotation = Quaternion.LookRotation(-(transform.position - status.target.transform.position));
        }*/
    }
}

