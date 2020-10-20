using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void restart()
    {
        GameObject single = GameObject.FindGameObjectWithTag("Singletons");
        Destroy(single);
        SceneManager.LoadScene("Intro");
    }
}
