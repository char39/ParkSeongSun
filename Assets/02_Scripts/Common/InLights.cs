using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class InLights : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    public Light inlight;
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            source.PlayOneShot(clip);
            inlight.enabled = true;
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            inlight.enabled = false;
        }
    }


}
