using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static Vector2 bottomLeft;

    public static bool gameOver;
    public static bool gameHasStarted;
    public static bool gamePaused;
    public static int gameScore;

    [SerializeField] GameObject gameOverCanvas;
    [SerializeField] Score score;
    [SerializeField] GameObject getReady;
    [SerializeField] GameObject pauseBtn;
    [SerializeField] Animator blackFade;
    [SerializeField] Text panelScore;

    int drawScore;

    private void Awake()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
    }

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        gameHasStarted = false;
        gamePaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        gameOver = true;
        gameScore = score.score;
        score.gameObject.SetActive(false);
        pauseBtn.SetActive(false);
        Invoke("ActivateGameOver", 1);
    }

    void ActivateGameOver()
    {
        gameOverCanvas.SetActive(true);
        AudioManager.audiomanager.Play("die");
    }

    public void OnOkBtnPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        AudioManager.audiomanager.Play("transition");
    }

    public void OnMenuBtnPressed()
    {
        //SceneManager.LoadScene("Menu");
        blackFade.SetTrigger("FadeIn");
        AudioManager.audiomanager.Play("transition");
    }

    public void DrawScore()
    {
        if (drawScore <= gameScore)
        {
            panelScore.text = drawScore++.ToString();
            Invoke("DrawScore", 0.3f / Mathf.Sqrt(gameScore + 1 - drawScore));
        }
    }

    public void GameHasStarted()
    {
        gameHasStarted = true;
        score.gameObject.SetActive(true);
        getReady.SetActive(false);
        pauseBtn.SetActive(true);
    }
}
