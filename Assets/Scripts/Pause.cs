using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    Image img;

    [SerializeField] Sprite playSprite;
    [SerializeField] Sprite pauseSprite;

    private void Start()
    {
        img = GetComponent<Image>();
    }

    public void OnPauseGame()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            img.sprite = playSprite;
        }
        else
        {
            Time.timeScale = 1;
            img.sprite = pauseSprite;
        }
    }
}
