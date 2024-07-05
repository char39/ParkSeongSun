using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Containers : MonoBehaviour
{
    public GameObject sparkEffect;
    public AudioSource source;
    public AudioClip clip;
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "BULLET")
        {
            source.PlayOneShot(clip);
            GameObject spark = Instantiate(sparkEffect, col.transform.position, Quaternion.identity);
            Destroy(spark, 1.0f);
            Destroy(col.gameObject);
        }
    }
    void Update()
    {

    }
}
