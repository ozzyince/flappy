using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] float speed;
    float width;

    // Start is called before the first frame update
    void Start()
    {
        if (CompareTag("Ground"))
            width = GetComponent<BoxCollider2D>().size.x;
        else
            width = -(GameManager.bottomLeft.x - GameObject.FindGameObjectWithTag("Pipe").GetComponent<BoxCollider2D>().size.x);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameOver) return;
        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        if (transform.position.x < -width)
            if (CompareTag("Ground"))
                transform.position = new Vector2(transform.position.x + 2 * width, transform.position.y);
            else if (CompareTag("Column"))
                Destroy(gameObject);
    }
}
