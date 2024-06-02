using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    public GameObject startScreen;
    public timer2 gameTimer; // Reference to your timer2 script

 public GameManager gameManager; // Reference to your GameManager script

 public void Start()
 {
Time.timeScale = 0;
 }

    public void StartButtonClicked()
    {

        Time.timeScale = 1;
        // Deactivate the start screen
        startScreen.SetActive(false);

        // Activate the timer
        gameTimer.timerIsRunning = true;

        gameManager.StartLevel();

        gameManager.ResetSlider();
    }
}
