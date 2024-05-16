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
        AudioManager.instance.StopMusic();  // Sicherstellen, dass vorherige Musik gestoppt wird
        AudioManager.instance.PlayMainMenuMusic(mainMenuMusic);  // Menü-Musik abspielen
    }
    public void PlayGame()
    {
        //nächste Szene laden
        // Reset the time scale to its normal value before loading the next scene
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // Soundeffekt abspielen
        AudioManager.instance.PlaySFX(click);
        // Main Menu Music stoppen
        AudioManager.instance.StopMusic();
        // In-Game:Musik abspielen
        // AudioManager.instance.PlayInGameMusic(inGameMusic);
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