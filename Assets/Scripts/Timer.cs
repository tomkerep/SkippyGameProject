using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    Slider timeSlider;
    

    public timer2 gameTimer; // Reference to your timer2 script

    private bool levelStarted = false; // Flag to track if the level has started

    void Start()
    {
        timeSlider = GetComponent<Slider>();
        timeSlider.maxValue = gameTimer.timeRemaining;
        timeSlider.value = timeSlider.maxValue;
    
    }

    void FixedUpdate()
    {
        // Only update slider if the level has started and the timer is running
        if (levelStarted && gameTimer != null && gameTimer.timerIsRunning)
        {
            
            timeSlider.value = Mathf.Max(gameTimer.timeRemaining, 0);
        }
    }

    // Function to reset the slider
    public void ResetSlider()
    {
        timeSlider.value = timeSlider.maxValue;
        
    }

    // Function to indicate that the level has started
    public void StartLevel()
    {
        levelStarted = true;
    }

}

/*
public class GameManager : MonoBehaviour
{
    Slider timeSlider;
    public float gameTime;
    
   // private bool stopTimer;

    void Start(){

        timeSlider = GetComponent<Slider>();

      //  stopTimer = false;
        timeSlider.maxValue = gameTime;
        timeSlider.value = gameTime; 
    }
       // console.log(Time.deltaTime;);
    

    void FixedUpdate(){
        float time = gameTime - Time.time;

        if(time <= 0){
           // stopTimer = true;
           time = gameTime;
        //    timeSlider.value = gameTime;
        }

            timeSlider.value = time;
        }
    }

*/
