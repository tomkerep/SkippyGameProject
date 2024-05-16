using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Selection : MonoBehaviour
{

    public static int selectedLevel;
    public int level;
    public AudioClip click;
    public AudioClip inGameMusic;

    public void OpenScene()
    {
        // Reset the time scale to its normal value before loading the main menu scene
        Time.timeScale = 1;
        selectedLevel = level;
        SceneManager.LoadScene("Level " + level.ToString());
        // Main Menu Music stoppen
        AudioManager.instance.StopMusic();
        // Soundeffekt abspielen
        AudioManager.instance.PlaySFX(click);
        // In-Game:Musik abspielen
        AudioManager.instance.PlayInGameMusic(inGameMusic);
    }

}
