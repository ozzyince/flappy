using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] float speed = 2;
    [SerializeField] GameManager gameManager;
    [SerializeField] Sprite birdDied;

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
        score = FindObjectOfType<Score>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !GameManager.gameOver)
        {
            body.gravityScale = 0.8f;
            gameManager.GameHasStarted();
            body.velocity = new Vector2(0, speed);
        }
        if (!touchedGround)
        {
            angle = Mathf.Clamp(angle + (body.velocity.y > 0 ? 4 : body.velocity.y < -1.3f ? -3 : 0), minAngle, maxAngle);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Column"))
            score.Scored();
        else if (collision.CompareTag("Pipe"))
            gameManager.GameOver();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            if (!GameManager.gameOver)
            {
                gameManager.GameOver();
                GameOver();
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
}
