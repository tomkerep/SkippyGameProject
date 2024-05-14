using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioClip click;
    public AudioClip mainMenuMusic;
    public AudioClip inGameMusic;
    void Start()
    {
        AudioManager.instance.PlayMainMenuMusic(mainMenuMusic);
    }
    public void PlayGame()
    {
        // nächste Szene laden
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // Soundeffekt abspielen
        AudioManager.instance.PlaySFX(click);
        AudioManager.instance.StopMusic(); // Main Menu Music stoppen
        AudioManager.instance.PlayInGameMusic(inGameMusic);
    }
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
        /* if (Application.isEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }*/
    }
}