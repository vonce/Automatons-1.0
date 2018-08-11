using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour, IAction
{
    private Status status;
    private Vector3 moveDirection;

    public ActionE enumID()
    {
        return ActionE.Move;
    }
    void Start()
    {
        status = GetComponent<Status>();
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
            moveDirection = Vector3.ProjectOnPlane(transform.position - target.transform.position, transform.up);
            transform.rotation = Quaternion.LookRotation( -moveDirection, transform.up);
            transform.position = Vector3.MoveTowards(transform.position, transform.position - moveDirection, status.speed * Time.deltaTime);
        }
    }
}
