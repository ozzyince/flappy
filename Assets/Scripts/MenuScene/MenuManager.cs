using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Animator blackFade;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayBtnPressed()
    {
        //SceneManager.LoadScene("Game");
        blackFade.SetTrigger("FadeIn");
    }
}
