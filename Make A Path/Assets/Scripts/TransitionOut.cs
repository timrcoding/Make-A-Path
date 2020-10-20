using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TransitionOut : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI timer;
    void Start()
    {
        float time = Counter.instance.timer;
        float rounded = Mathf.Round(time * 10) / 10;
        timer.text = rounded.ToString() ;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
