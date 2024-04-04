using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    Slider timeSlider;
    public float gameTime;
    
    private bool stopTimer;

    void Start(){

        timeSlider = GetComponent<Slider>();

        stopTimer = false;
        timeSlider.maxValue = gameTime;
        timeSlider.value = gameTime; 
    }
       // console.log(Time.deltaTime;);
    

    void FixedUpdate(){
        float time = gameTime - Time.time;

        if(time <= 0){
            stopTimer = true;
        }

        if(stopTimer == false){
            timeSlider.value = time;
        }
    }
}

