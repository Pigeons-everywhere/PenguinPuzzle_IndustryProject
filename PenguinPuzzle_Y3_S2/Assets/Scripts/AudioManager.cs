using UnityEngine;
using System;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] musicSounds, sfxSounds, ambientSounds;
    public AudioSource musicSource, sfxSource, ambientSourceManager;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else 
        { 
            Destroy(gameObject); 
        }
    }

    private void Start()
    {
        PlayMusic("Theme");
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x=> x.name == name);

        if (s == null)
        {
            Debug.Log("No Music found with name" + name);
            return;
        }

        else
        {
            musicSource.clip = s.clip;
            musicSource.volume = s.volume;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("No SFX found with name" + name);
            return;
        }

        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }

    public void PlayAmb(string name)
    {
        Sound s = Array.Find(ambientSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("No Amb  found with name" + name);
            return;
        }

        foreach (AudioSource src in ambientSourceManager.GetComponentsInChildren<AudioSource> ())
        {
            src.clip = s.clip;
            src.volume = s.volume;  
            src.Play();
        }
    }

    //mute
    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }
    public void ToggleAmb()
    {
        foreach (AudioSource src in ambientSourceManager.GetComponentsInChildren<AudioSource>())
        { 
            src.mute = !src.mute; 
        }
    }
    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }


    //volume
    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }
    public void AmbVolume(float volume)
    {
        foreach (AudioSource src in ambientSourceManager.GetComponentsInChildren<AudioSource>())
        {  
            src.volume = volume;
        }
    }
    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}
