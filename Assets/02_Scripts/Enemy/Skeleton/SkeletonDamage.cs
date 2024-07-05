using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkeletonDamage : MonoBehaviour
{
    public CapsuleCollider capcol;
    public Rigidbody rb;
    public Animator ani;
    public Image hpBar;
    public Text hpText;
    public int hp = 0;
    public int maxHp = 100;
    public SkeletonCtrl skeletonCtrl;
    public GameObject bloodEffect;
    public Transform tr;
    public Transform playerTr;
    public GunFireCtrl gunFireCtrl;
    public BoxCollider boxCol;
    public MeshRenderer meshRend;
    void Start()
    {
        capcol = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();
        skeletonCtrl = GetComponent<SkeletonCtrl>();
        tr = GetComponent<Transform>();
        playerTr = GameObject.FindWithTag("Player").GetComponent<Transform>();
        gunFireCtrl = GameObject.FindWithTag("Player").GetComponent<GunFireCtrl>();
        hp = maxHp;
        hpText.color = Color.blue;
        hpText.text = $"HP : <color=#FF0000>100</color>";
    }
    void Update()
    {
        if (hpBar.fillAmount <= 0.2f)
            hpBar.color = Color.red;
        else if (hpBar.fillAmount <= 0.5f)
            hpBar.color = Color.yellow;
        else
            hpBar.color = Color.green;
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "BULLET")
        {
            hp -= 20;
            HpInfo();
            Vector3 hitPos = col.transform.position;
            Vector3 fireNormal = col.transform.position - gunFireCtrl.firePos.position;
            fireNormal = -fireNormal.normalized;
            Quaternion hitRot = Quaternion.LookRotation(fireNormal);
            GameObject blood = Instantiate(bloodEffect, hitPos, hitRot);
            Destroy(blood, 1.0f);
            Destroy(col.gameObject);
            if (hp <= 0)
            {
                hp = 0;
                SkeletonDie();
            }
        }
    }
    public void ColiderOn()
    {
        boxCol.enabled = true;
        meshRend.enabled = true;
    }
    public void ColiderOff()
    {
        boxCol.enabled = false;
        meshRend.enabled = false;
    }
    void SkeletonDie()
    {
        capcol.enabled = false;
        rb.isKinematic = true;
        ani.SetTrigger("DieTrigger");
        skeletonCtrl.isDie = true;
        GameManager.killCount++;
        Destroy(gameObject, 5.0f);
    }

    void HpInfo()
    {
        hpBar.fillAmount = (float)hp / (float)maxHp;
        hpText.text = $"HP : <color=#FF0000>{hp.ToString()}</color>";
    }
}
