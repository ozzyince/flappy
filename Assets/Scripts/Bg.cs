using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bg : MonoBehaviour
{
    [SerializeField] float speed;
    float width = 1.43f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameOver) return;
        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        if (transform.position.x < -width)
            transform.position = new Vector2(transform.position.x + 2 * width, transform.position.y);
    }
}
