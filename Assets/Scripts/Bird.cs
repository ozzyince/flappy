using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] float speed = 2;
    [SerializeField] GameManager gameManager;
    [SerializeField] Sprite birdDied;
    [SerializeField] Animator birdParent;
    [SerializeField] Animator getReady;
    [SerializeField] Animator hitEffect;
    [SerializeField] Animator cameraAnim;

    Rigidbody2D body;
    Score score;
    SpriteRenderer spriteRenderer;
    Animator animator;

    int maxAngle = 20;
    int minAngle = -90;
    int angle;

    bool touchedGround = false;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.gravityScale = 0;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !GameManager.gameOver && Time.timeScale == 1)
        {
            body.gravityScale = 0.8f;
            birdParent.enabled = false;
            body.velocity = new Vector2(0, speed);
            score = FindObjectOfType<Score>();
            getReady.SetTrigger("FadeOut");
            AudioManager.audiomanager.Play("flap");
        }
        if (GameManager.gameHasStarted && !touchedGround)
        {
            body.gravityScale = body.velocity.y > 0 ? 0.8f : 0.6f;
            angle = Mathf.Clamp(angle + (body.velocity.y > 0 ? 4 : body.velocity.y < -1.3f ? -3 : 0), minAngle, maxAngle);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.gameOver) return;
        if (collision.CompareTag("Column"))
        {
            AudioManager.audiomanager.Play("point");
            score.Scored();
        }
        else if (collision.CompareTag("Pipe"))
        {
            hitEffect.SetTrigger("Hit");
            cameraAnim.SetTrigger("Shake");
            gameManager.GameOver();
            AudioManager.audiomanager.Play("hit");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            if (!GameManager.gameOver)
            {
                hitEffect.SetTrigger("Hit");
                cameraAnim.SetTrigger("Shake");
                gameManager.GameOver();
                GameOver();
                AudioManager.audiomanager.Play("hit");
            }
            else
            {
                touchedGround = true;
                GameOver();
            }
    }

    void GameOver()
    {
        animator.enabled = false;
        spriteRenderer.sprite = birdDied;
        transform.rotation = Quaternion.Euler(0, 0, -90);
    }

    public void OnGetReadyAnimFinished()
    {
        gameManager.GameHasStarted();
    }
}
