using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlackFade : MonoBehaviour
{
    void OnBlackFadeFinished()
    {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % 2);
    }
}
