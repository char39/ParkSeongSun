using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    public float speed = 10.0f;
    public Rigidbody rb;
    public int damage = 20;
    void Start()
    {
        rb.AddForce(transform.forward * speed);
        Destroy(this.gameObject, 3.0f);
    }

    void Update()
    {
        
    }
}
