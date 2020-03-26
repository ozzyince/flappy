using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int score;
    Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        SetScore(0);
    }

    private void SetScore(int v)
    {
        score = v;
        text.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Scored()
    {
        SetScore(score + 1);
    }
}
