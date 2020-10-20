using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScores : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scores;
    void Start()
    {
        setScores();
    }

    void setScores()
    {
        scores.text = "";
        for(int i = 0; i < LevelManager.instance.levelScore.Length; i++)
        {
            scores.text += "1." + i.ToString() + ": " + LevelManager.instance.levelScore[i].ToString() + '\n';
        }
    }
}
