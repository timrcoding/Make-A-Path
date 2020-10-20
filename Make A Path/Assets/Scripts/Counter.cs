using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    public static Counter instance;

    [SerializeField]
    public float timer;
    [SerializeField]
    public bool startTimer;
    [SerializeField]
    public TextMeshProUGUI levelCounterText;

    [SerializeField]
    private TextMeshProUGUI timerText;

    void Start()
    {
        instance = this;
        levelCounterText.text = "Level 1." + LevelManager.instance.level.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer)
        {
            stopWatch();
        }
    }

    void stopWatch()
    {
        timer += Time.deltaTime;
        float rounded = Mathf.Round(timer * 10) / 10;
        timerText.text = rounded.ToString();
    }

    public void setText(float f)
    {
        timerText.text = f.ToString();
    }

    float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }

    public void resetTimer()
    {
        timer = 0;
    }
}
