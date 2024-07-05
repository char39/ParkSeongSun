using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    public Text finalKillCounts;
    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        if (SceneManager.GetActiveScene().name == "EndScene")
        {
            EndScenes();
        }
    }
    public void EndScenes()
    {
        finalKillCounts = GameObject.Find("Text_KillCounts").GetComponent<Text>();
        finalKillCounts.text = $"Kill : {GameManager.killCount.ToString()}";
    }
    public void startGame()
    {
        SceneManager.LoadScene("PlayScene");
    }
    public void endGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
