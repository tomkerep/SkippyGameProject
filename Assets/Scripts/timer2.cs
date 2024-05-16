using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timer2 : MonoBehaviour
{
    public float timeRemaining = 0;
    public bool timerIsRunning = false;

    public int NutsNeeded;
    public int NutsNeededStar2;
    public int NutsNeededStar3;

    public GameOverScreen gameOverScreen;

    public GameWonScreen gameWonScreen;
    public GameObject Bau;
    public GameObject PausePanel;
    private bool isPaused = false;
    private void Start()
    {

    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;

            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;

                GameCheck();
            }
        }
        if (timeRemaining > 0 && Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Debug.Log("Resume");
                Resume();
            }
            else
            {
                Debug.Log("Pause");
                Pause();

            }
        }
    }
    public void GameCheck()
    {
        BauInventory bauInventory = Bau.GetComponent<BauInventory>();

        if (bauInventory.StoredNuts < NutsNeeded)
        {
            gameOverScreen.Setup(bauInventory.StoredNuts);
            if (gameOverScreen == true)
            {
                Debug.Log("Game Over");
                Time.timeScale = 0;
            }
        }
        else
        {
            gameWonScreen.Setup(bauInventory.StoredNuts);
            if (gameWonScreen == true)
            {
                Debug.Log("Game Won");
                Time.timeScale = 0;
            }
        }
    }

    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }
    public void Resume()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }
    public void QuitGame()
    {
        Debug.Log("QUIT!");
       
            Application.Quit();
        
    }
    public void ReturnToMainMenu()
    {
        // Reset the time scale to its normal value before loading the main menu scene
        Time.timeScale = 1;

        SceneManager.LoadScene("Hauptmenü");
    }

    public float GetRemainingTime()
    {
        return timeRemaining;
    }
}