using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ViewController : MonoBehaviour
{
    [Serializable]
    public class Data
    {
        public TMP_Text text;
        public string value;
    }

    public Data[] data;
    public TMP_Text scoreValue;
    public TMP_Text scoreValueOutline;
    public StarUI scoreUI;
    public Scrollbar scrollbar;
    public Animator animatorL;
    public Animator animatorR;
    private float start;
    private float end;
    private float t;
    private float animationLengh = 2;
    private bool isSliding;


    void Start()
    {
        foreach (Data elem in data)
        {
            elem.text.text = elem.value;
        }
        scrollbar.value = 0;
        scrollbar.onValueChanged.AddListener(ScrollbarCallback);
        scoreValue.text = PlayerPrefs.GetInt("score", 57).ToString();
        scoreValueOutline.text = PlayerPrefs.GetInt("score", 57).ToString();
    }

    void ScrollbarCallback(float value)
    {
        if (value > 0)
        {
            animatorL.gameObject.SetActive(true);
        }
        else
        {
            animatorL.Play("BlackWallAnimReversed");
        }
        if (value < 1)
        {
            animatorR.gameObject.SetActive(true);
        }
        else
        {
            animatorR.Play("BlackWallAnimReversed");
        }

    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("score", Convert.ToInt32(scoreValue.text));
        Debug.Log("Save Completed");
    }

    public void AddScore(int score)
    {
        scoreUI.addition = score;
        scoreUI.isStart = false;
        scoreUI.transform.GetComponent<Animator>().Rebind();
    }

    public void SlidingToTheEdge(float value)
    {
        if (isSliding) return;
        start = scrollbar.value;
        end = value;
        isSliding = true;
    }

    void Update()
    {
        if (!isSliding)
        {
            t = 0.0f;
        }
        else
        {
            t = Mathf.MoveTowards(t, 1.0f, Time.deltaTime / animationLengh);
            scrollbar.value = Mathf.Lerp(start, end, t);
            if (scrollbar.value == end)
            {
                isSliding = false;
            }
        }
    }
}
