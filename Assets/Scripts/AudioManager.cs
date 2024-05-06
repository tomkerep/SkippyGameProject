using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    //Versuch 1
        // [Header("----Audio Sources----")]
        // [SerializeField] AudioSource musicSource;
        // [SerializeField] AudioSource sfxSource;

        // [Header("----Audio Clips----")]
        // public AudioClip backgroundMusic;
        // public AudioClip pickUp;
        // public AudioClip drop;
        // public AudioClip hit;
        // public AudioClip win;
        // public AudioClip lose;

        // public void start()
        // {
        //     musicSource.clip = backgroundMusic;
        //     musicSource.Play();
        // }
    
    //Versuch 2

        // public static AudioManager instance;
        // public Sound[] music, sfxSounds;
        // public AudioSource musicSource, sfxSource;

        // private void Awake()
        // {
        //     if (instance == null)
        //     {
        //         instance = this;
        //         DontDestroyOnLoad(gameObject);
        //     }else
        //     {
        //         Destroy(gameObject);
        //     }
        // }

        // public void PlayMusic(string name)
        // {
        //     Sound s = Array.Find(music, x => x.name == name);
        //     if (s == null)
        //     {
        //         Debug.LogWarning("Sound not found!");
        //     }else
        //     {
        //         musicSource.clip = s.clip;
        //         musicSource.Play();
        //     }
        // }

        // private void start()
        // {
        //     PlayMusic("backgroundMusic");
        // }

        // public void PlaySFX(string name)
        // {
        //     Sound s = Array.Find(sfxSounds, x => x.name == name);
        //     if (s == null)
        //     {
        //         Debug.LogWarning("Sound not found!");
        //     }else{
        //         sfxSource.PlayOneShot(s.clip);
        //     }
        // }
}