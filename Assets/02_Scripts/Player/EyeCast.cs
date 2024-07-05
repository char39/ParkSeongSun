using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeCast : MonoBehaviour
{
    public Transform tr;
    public Ray ray;
    public RaycastHit hitInfo;
    public float distance = 20.0f;
    public CrossHair crossHair;
    void Start()
    {
        tr = GetComponent<Transform>();
        crossHair = GameObject.Find("Canvas_UI").transform.GetChild(6).GetComponent<CrossHair>();
    }

    void Update()
    {
        ray = new Ray(tr.position, tr.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.green);
        if (Physics.Raycast(ray, out hitInfo, distance, 1<<6))
        {
            crossHair.isGaze = true;
        }
        else
        {
            crossHair.isGaze = false;
        }
    }
}
