using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private AudioSource audioS;

    void Start()
    {
        instance = this;
        audioS = GetComponent<AudioSource>();
    }

    public void turnTheme
}
