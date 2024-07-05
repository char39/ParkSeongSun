using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.ParticleSystemJobs;
public class GunFireCtrl : MonoBehaviour
{
    public GameObject bullet;
    public ParticleSystem muzzleFlash;
    public Transform firePos;
    public AudioSource source;
    public AudioClip clipFire;
    public Animation ani;
    public float fireRate = 0.1f;
    public float fireTime = 0f;
    public bool isReload = false;
    public int fireCount = 0;

    void Start()
    {
        fireTime = Time.time;
        muzzleFlash.Stop();
    }

    void Update()
    {
        if ((Time.time - fireTime > fireRate) && Input.GetMouseButton(0) && !isReload && !PlayerCtrl.isRun)
        {
            GunFire();
            muzzleFlash.Play();
        }
        else
            muzzleFlash.Stop();
    }

    private void GunFire()
    {
        source.PlayOneShot(clipFire);
        ani.Play("fire");
        Instantiate(bullet, firePos.position, firePos.rotation);
        fireTime = Time.time;
        fireCount++;
        if (fireCount >= 10)
            StartCoroutine("Reload");
    }
    IEnumerator Reload()
    {
        isReload = true;
        yield return new WaitForSeconds(0.1f);
        ani.Play("pump3");
        yield return new WaitForSeconds(0.8f);
        fireCount = 0;
        isReload = false;
    }
}
