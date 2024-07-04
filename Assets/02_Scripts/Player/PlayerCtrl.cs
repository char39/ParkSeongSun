using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerCtrl : MonoBehaviour
{
    public Animation ani;
    public AudioSource source;
    public AudioClip clipFlash;
    public Light flashLight;
    public bool isRun = false;
    void Start()
    {
        
    }

    void Update()
    {
        isRunning();
        FlashCtrl();
    }

    private void FlashCtrl()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            source.PlayOneShot(clipFlash);
            flashLight.enabled = !flashLight.enabled;
        }
    }

    public void isRunning()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            ani.Play("running");
            isRun = true;
        }
        else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.A))
        {
            ani.Play("running");
            isRun = true;
        }
        else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.S))
        {
            ani.Play("running");
            isRun = true;
        }
        else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.D))
        {
            ani.Play("running");
            isRun = true;
        }
        else if ((!Input.GetKey(KeyCode.LeftShift) || !Input.GetKey(KeyCode.W)) && isRun)
        {
            ani.Play("idle");
            isRun = false;
        }
    }
}
