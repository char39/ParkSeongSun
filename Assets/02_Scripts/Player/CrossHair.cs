using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossHair : MonoBehaviour
{
    public bool isGaze = false;
    public Transform tr;
    public Image cross;
    public float startTime;
    public float duration = 0.7f;
    public float minSize = 0.5f;
    public float maxSize = 1.0f;
    public Color originColor = Color.white;
    public Color gazeColor = Color.red;
    void Start()
    {
        tr = transform;
        cross = GetComponent<Image>();
        startTime = Time.time;
        tr.localScale = Vector3.one * maxSize;
    }

    void Update()
    {
        if (isGaze)
        {
            float time = (Time.time - startTime) / duration;
            tr.localScale = Vector3.one * Mathf.Lerp(maxSize, minSize, time);
            cross.color = gazeColor;
        }
        else
        {
            tr.localScale = Vector3.one * maxSize;
            cross.color = originColor;
            startTime = Time.time;
        }
    }
}
