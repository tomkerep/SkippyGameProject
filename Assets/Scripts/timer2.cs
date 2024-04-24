using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timer2 : MonoBehaviour
{
    public float timeRemaining = 10;
    public bool timerIsRunning = false;

    public int NutsNeeded;

    public GameOverScreen gameOverScreen;

    public GameWonScreen gameWonScreen;
    public GameObject Bau;
    public GameObject PausePanel;
    private bool isPaused = false;
    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Debug.Log("Resume");
                Resume();
            }else{
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
        }
        else
        {
            gameWonScreen.Setup(bauInventory.StoredNuts);
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
        if (Application.isEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Hauptmenü");
    }
}