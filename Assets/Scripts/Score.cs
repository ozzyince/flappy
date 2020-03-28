using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score;
    int highScore;
    Text text;

    [SerializeField] Text panelScore;
    [SerializeField] Text panelHighScore;
    [SerializeField] GameObject newHigh;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        highScore = PlayerPrefs.GetInt("highScore", 0);
        panelHighScore.text = highScore.ToString();
        SetScore(0);
    }

    private void SetScore(int v)
    {
        score = v;
        text.text = score.ToString();
        //panelScore.text = text.text;
        if (score > highScore)
        {
            highScore = score;
            panelHighScore.text = highScore.ToString();
            PlayerPrefs.SetInt("highScore", highScore);
            newHigh.SetActive(true);
        }
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
