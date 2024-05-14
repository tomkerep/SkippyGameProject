using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource musicSource;
    public AudioSource sfxSource;

    void Awake()
    {
        if (instance == null) // Wenn es noch keine Instanz von AudioManager gibt, erstelle eine
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        // Initialisiere die AudioSources
        musicSource = gameObject.AddComponent<AudioSource>();
        sfxSource = gameObject.AddComponent<AudioSource>();
    }

    // Methode zum Abspielen von Menü-Musik
    public void PlayMainMenuMusic(AudioClip musicClip)
    {
        // Überprüft, ob bereits ein Clip abgespielt wird
        if(!musicSource.isPlaying)
        {
            musicSource.clip = musicClip;
            musicSource.Play();
            Debug.Log("Main Menu Music started");
        }
    }
    // Methode zum Abspielen von In-Game-Musik
    public void PlayInGameMusic(AudioClip musicClip)
    {
        // Überprüft, ob bereits ein Clip abgespielt wird
        if(!musicSource.isPlaying)
        {
            musicSource.clip = musicClip;
            musicSource.Play();
            Debug.Log("In-Game Music started");
        }
    }
    // Methode zum Stoppen von Hintergrundmusik
    public void StopMusic()
    {
        musicSource.Stop();
        Debug.Log("Music stopped");
    }
    // Methode zum Abspielen von Soundeffekten
    public void PlaySFX(AudioClip sfxClip)
    {
        sfxSource.PlayOneShot(sfxClip);
    }
}