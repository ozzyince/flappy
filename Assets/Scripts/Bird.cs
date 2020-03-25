using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] float speed = 2;

    Rigidbody2D body;

    int maxAngle = 20;
    int minAngle = -90;
    int angle;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            body.velocity = new Vector2(0, speed);
        angle = Mathf.Clamp(angle + (body.velocity.y > 0 ? 4 : body.velocity.y < -1.3f ? -3 : 0), minAngle, maxAngle);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
