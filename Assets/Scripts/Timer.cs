using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Slider timeSlider;
    public float gameTime;
    
    private bool stopTimer;

    void Start(){

        stopTimer = false;
        timeSlider.maxValue = gameTime;
        timeSlider.value = gameTime; 
    }

    void Update(){
        float time = gameTime - Time.time;

        if(time <= 0){
            stopTimer = true;
        }

        if(stopTimer == false){
            timeSlider.value = time;
        }
    }}


