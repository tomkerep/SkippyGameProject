using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class timer2 : MonoBehaviour
{
    public float timeRemaining = 10;
    public bool timerIsRunning = false;

    public int NutsNeeded;
    public int NutsNeededStar2;
    public int NutsNeededStar3;

    public GameOverScreen gameOverScreen;

    public GameWonScreen gameWonScreen;
    public GameObject Bau;

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


}