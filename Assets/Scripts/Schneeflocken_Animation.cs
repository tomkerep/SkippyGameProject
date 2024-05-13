using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schneeflocken_Animation : MonoBehaviour
{

   private float timeRemaining; 
   public Animator animator;

   public timer2 gameTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log("timeRemaining: " + timeRemaining);
        timeRemaining = gameTime.GetRemainingTime();

        // Setzen Sie die verbleibende Zeit für die Animation
        animator.SetFloat("timeRemaining", timeRemaining);

    }
}
