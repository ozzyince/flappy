using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnSpawner : MonoBehaviour
{
    [SerializeField] GameObject column;
    [SerializeField] float maxY;
    [SerializeField] float minY;
    float lastTime;
    float rnd;

    // Start is called before the first frame update
    void Start()
    {
        rnd = Random.Range(2, 4);
        lastTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameOver) return;
        if (Time.time - lastTime > rnd)
        {
            lastTime = Time.time;
            InstantiateColumn();
            rnd = Random.Range(2, 4);
        }
    }

    void InstantiateColumn()
    {
        var newColumn = Instantiate(column);
        newColumn.transform.position = new Vector2(transform.position.x, Random.Range(minY, maxY));
    }
}
