using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetReady : MonoBehaviour
{
    [SerializeField] Bird bird;

    void OnGetReadyAnimEnds()
    {
        bird.OnGetReadyAnimFinished();
    }
}
