using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    public GameObject parentUnit;
    public GameObject target;
    public float tick;
    private float nextTick;
    private LineRenderer lineRenderer;
    private HashSet<Collider> inBeam = new HashSet<Collider>();
    private Gradient gradient = new Gradient();

    void Start()
    {
        nextTick = Time.time + tick;
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        if (gameObject.tag == "Blue")
        {
            gradient.SetKeys(
                new GradientColorKey[] { new GradientColorKey(Color.white, 0.0f), new GradientColorKey(Color.blue, 1.0f) },
                new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(1.0f, 1.0f) }
                );
        }
        if (gameObject.tag == "Red")
        {
            gradient.SetKeys(
                new GradientColorKey[] { new GradientColorKey(Color.white, 0.0f), new GradientColorKey(Color.red, 1.0f) },
                new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(1.0f, 1.0f) }
                );
        }
        if (gameObject.tag == "Green")
        {
            gradient.SetKeys(
                new GradientColorKey[] { new GradientColorKey(Color.white, 0.0f), new GradientColorKey(Color.green, 1.0f) },
                new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(1.0f, 1.0f) }
                );
        }
        lineRenderer.colorGradient = gradient;
    }
    // Update is called once per frame
    void Update()
    {

        if (parentUnit == null || parentUnit.GetComponent<Status>().target != target || parentUnit.GetComponent<Status>().active == false )
        {
            Destroy(gameObject);
        }
        if (parentUnit != null)
        {
            gameObject.transform.localScale = new Vector3(1, 1, parentUnit.GetComponent<Primary>().targetDistance);
        }
        
        if (nextTick <= Time.time)
        {
            foreach (Collider collider in inBeam)
            {

                if (collider != null)
                {
                    collider.GetComponentInParent<Status>().HealthChange(-1);
                }
                nextTick = Time.time + tick;
            }
            if( tick > .2)
            {
                tick -= .1f;
            }
        }
    }

    void OnTriggerEnter(Collider other)//trigger events
    {
        if (inBeam.Contains(other) == false && other.gameObject.GetComponentInParent<Status>() != null)
        {
            inBeam.Add(other);
        }
    }

    void OnTriggerStay(Collider other)//trigger events
    {
        if (inBeam.Contains(other) == false && other.gameObject.GetComponentInParent<Status>() != null)
        {
            inBeam.Add(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (inBeam.Contains(other) == true)
        {
            inBeam.Remove(other);
        }
    }

}
