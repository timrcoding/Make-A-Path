using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public int level;
    public int[] difficulties;
    public int levelDifficulty;
    public int levelCap;
    public float[] levelScore;
    void Start()
    {
        instance = this;
        setLevelDifficulty();
    }

    public void setLevelScore(float f)
    {
        if (checkForHighScore(f))
        {
            Debug.Log("SCORE SET");
            levelScore[level] = f;
        }
    }

    bool checkForHighScore(float i)
    {
        float levelS = levelScore[level];
        if(levelS == 0 || i < levelS)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void setLevelDifficulty()
    {

        
        if(level >= levelScore.Length)
        {
            SceneManager.LoadScene("Outro");
        }
        levelDifficulty = difficulties[level];
    }

    
}
