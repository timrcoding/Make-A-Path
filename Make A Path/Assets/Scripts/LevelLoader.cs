using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance;

    private void Start()
    {
        instance = this;
    }
    //LOADS AFTER SPECIFIC ALLOCATED WAIT TIME
    public IEnumerator loadNextOnTimer(int i)
    {
        yield return new WaitForSeconds(i);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void loadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void incrementLevelCount()
    {
        LevelManager.instance.level++;
    }
}
