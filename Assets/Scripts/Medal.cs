using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Medal : MonoBehaviour
{
    [SerializeField] Sprite normalMedal;
    [SerializeField] Sprite bronzeMedal;
    [SerializeField] Sprite silverMedal;
    [SerializeField] Sprite goldMedal;

    Image img;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();

        if (GameManager.gameScore > 2)
            img.sprite = goldMedal;
        else if (GameManager.gameScore > 1)
            img.sprite = silverMedal;
        else if (GameManager.gameScore > 0)
            img.sprite = bronzeMedal;
        else
            img.sprite = normalMedal;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
