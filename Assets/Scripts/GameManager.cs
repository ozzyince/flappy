using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static Vector2 bottomLeft;

    public static bool gameOver;
    public static bool gameHasStarted;
    public static bool gamePaused;

    [SerializeField] GameObject gameOverCanvas;
    [SerializeField] GameObject score;
    [SerializeField] GameObject getReady;
    [SerializeField] GameObject pauseBtn;
    [SerializeField] Animator blackFade;

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
        score.SetActive(false);
        pauseBtn.SetActive(false);
        Invoke("ActivateGameOver", 1);
    }

    void ActivateGameOver()
    {
        gameOverCanvas.SetActive(true);
    }

    public void OnOkBtnPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnMenuBtnPressed()
    {
        //SceneManager.LoadScene("Menu");
        blackFade.SetTrigger("FadeIn");
    }

    public void GameHasStarted()
    {
        gameHasStarted = true;
        score.SetActive(true);
        getReady.SetActive(false);
        pauseBtn.SetActive(true);
    }
}
