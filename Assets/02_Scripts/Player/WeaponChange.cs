using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChange : MonoBehaviour
{
    public SkinnedMeshRenderer spas12;
    public MeshRenderer[] ak47;
    public MeshRenderer[] m4a1;
    public Animation ani;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            WeaponChange1();
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            WeaponChange2();
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            WeaponChange3();
    }

    private void WeaponChange1()
    {
        ani.Play("draw");
        for (int i = 0; i < ak47.Length; i++)
            ak47[i].enabled = true;
        for (int i = 0; i < m4a1.Length; i++)
            m4a1[i].enabled = false;
        spas12.enabled = false;
    }
    private void WeaponChange2()
    {
        ani.Play("draw");
        for (int i = 0; i < ak47.Length; i++)
            ak47[i].enabled = false;
        for (int i = 0; i < m4a1.Length; i++)
            m4a1[i].enabled = true;
        spas12.enabled = false;
    }
    private void WeaponChange3()
    {
        ani.Play("draw");
        for (int i = 0; i < ak47.Length; i++)
            ak47[i].enabled = false;
        for (int i = 0; i < m4a1.Length; i++)
            m4a1[i].enabled = false;
        spas12.enabled = true;
    }

}
