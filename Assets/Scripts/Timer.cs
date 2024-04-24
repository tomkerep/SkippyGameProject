using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    Slider timeSlider;
    public float gameTime;


    void Start()
    {
        timeSlider = GetComponent<Slider>();
        timeSlider.maxValue = gameTime;
       // timeSlider.value = gameTime;
       ResetSlider();
    }

    void FixedUpdate()
    {
         float time = Mathf.Max(gameTime - Time.time, 0); // Ensures time doesn't go below 0

          if (time <= 0)
          {
              ResetSlider();
          }

        timeSlider.value = time;
    }

    // Function to reset the slider
    public void ResetSlider()
    {
        timeSlider.value = gameTime;
      //  timeSlider.maxValue = gameTime;
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
