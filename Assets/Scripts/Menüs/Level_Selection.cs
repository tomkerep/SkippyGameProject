using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Selection : MonoBehaviour
{

    public static int selectedLevel;
    public int level;
    public AudioClip click;

    public void OpenScene()
    {
        selectedLevel = level;
        SceneManager.LoadScene("Level " + level.ToString());
        AudioManager.instance.StopMusic(); // Main Menu Music stoppen
        // Soundeffekt abspielen
            AudioManager.instance.PlaySFX(click);
    }
    
}
