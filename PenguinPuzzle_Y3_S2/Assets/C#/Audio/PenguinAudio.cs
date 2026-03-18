using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PenguinAudio : MonoBehaviour
{
    public AudioClip penguWalkA;
    public AudioClip hoverA;
    public AudioClip slidingA;

    private Dictionary<string, AudioClip> audioVals = new Dictionary<string, AudioClip>() {};

    AudioSource penguAudio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        penguAudio = this.gameObject.GetComponent<AudioSource>();
        audioVals.Add("walk", penguWalkA);
        audioVals.Add("slide", slidingA);
        audioVals.Add("hover", hoverA);
    }

    public void StartPenguAudio(string whichClip)
    {
        if (penguAudio.isPlaying && audioVals[whichClip] == penguAudio.clip) return;

        penguAudio.clip = audioVals[whichClip];

        penguAudio.Play(0); 
    }
    public void StopPenguAudio()
    {
        penguAudio.Stop(); 
    }
}
