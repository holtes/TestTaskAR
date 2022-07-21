using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class StarUI : MonoBehaviour
{
    private bool startAnim = false;
    [SerializeField]
    private TMP_Text value;
    [SerializeField]
    private TMP_Text valueOutline;
    [SerializeField]
    private float highScoreAnimationLengh = 2;
    private float t = 0.0f;
    private int start;
    private int end;
    public int addition;
    public bool isStart = true; 

    public void ScoreUpdate()
    {
        if (isStart) return;
        startAnim = true;
        start = Convert.ToInt32(value.text);
        end = Convert.ToInt32(value.text) + addition;

    }

    public float EaseOutQuad(float k)
    {
        return k * (2f - k);
    }

    void Update()
    {
        if (!startAnim)
        {
            t = 0.0f;
        }
        else
        {
            t = Mathf.MoveTowards(t, 1.0f, Time.deltaTime/highScoreAnimationLengh);
            int displayedScore = (int)Mathf.Lerp(start, end, EaseOutQuad(t));
            value.text = displayedScore.ToString();
            valueOutline.text = displayedScore.ToString();
            if (displayedScore == end)
            {
                startAnim = false;
            }
        }
    }
}
