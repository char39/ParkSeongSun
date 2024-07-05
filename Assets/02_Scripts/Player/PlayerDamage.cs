using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour
{
    public Image hpBar;
    public Text hpText;
    public int hp = 0;
    public int maxHp = 100;
    public Image gameover;
    public Text gameoverText;
    public static bool isPlayerDie = false;
    void Start()
    {
        hp = maxHp;
        HpInfo();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "HITBOX" && !isPlayerDie)
        {
            hp -= 20;
            HpInfo();
            if (hp == 0)
                GameOver();
        }
    }
    void GameOver()
    {
        gameover.enabled = true;
        gameoverText.enabled = true;
        isPlayerDie = true;
        GameObject[] enemy = GameObject.FindGameObjectsWithTag("ENEMY");
        foreach (GameObject obj in enemy)
        {
            obj.SendMessage("PlayerDie", SendMessageOptions.DontRequireReceiver);
        }
        Invoke("EndScene", 3.0f);
    }
    void EndScene()
    {
        SceneManager.LoadScene("EndScene");
    }
    void HpInfo()
    {
        hpText.color = Color.white;
        hpBar.fillAmount = (float)hp / (float)maxHp;
        hpText.text = $"HP : <color=#FFAAAA>{hp.ToString()}</color>";
    }
    void Update()
    {
        Mathf.Clamp(hp, 0, maxHp);
        if (hpBar.fillAmount <= 0.2f)
            hpBar.color = Color.red;
        else if (hpBar.fillAmount <= 0.5f)
            hpBar.color = Color.yellow;
        else
            hpBar.color = Color.green;
    }
}
