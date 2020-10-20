using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private AudioSource audioS;
    [SerializeField]
    private AudioClip theme;

    void Start()
    {
        instance = this;
        audioS = GetComponent<AudioSource>();
    }

    public void startTheme()
    {

        audioS.Play();
    }

    public void stopTheme()
    {
        audioS.Stop();
 
    }

    public void playClip(string clip,float vol)
    {
        //LOADS CLIP AS DEFINED BY STRING FROM RESOURCES
        AudioClip clipPlayed = Resources.Load("Sounds/" + clip.ToString()) as AudioClip;
        //PLAYS CLIP
        audioS.PlayOneShot(clipPlayed,vol);
        Debug.Log("CLIP PLAYED");
    }
}
