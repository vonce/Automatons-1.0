using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public float g;

    public void gravity(Transform unitTransform)
    {
        Vector3 gravityUp = (unitTransform.position - gameObject.transform.position).normalized;//direction of up vector relative to pos on moon
        Vector3 currentUp = unitTransform.up;//curent angle of up

        unitTransform.GetComponent<Rigidbody>().AddForce(gravityUp * g);//add gravity

        Quaternion targetRotation = Quaternion.FromToRotation(currentUp, gravityUp) * unitTransform.rotation;//change current up to new gravity up
        unitTransform.rotation = Quaternion.Slerp(unitTransform.rotation, targetRotation, 50f * Time.deltaTime);//calculate every 50 delta time

    }
}
