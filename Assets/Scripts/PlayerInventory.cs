using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfNuts { get; set; }
    public int MaxNumberOfNuts = 4;
    public UnityEvent<PlayerInventory> OnNutCollected; 
    public AudioClip collect_nut;

    public void NutCollected()
    {
        if(NumberOfNuts >= MaxNumberOfNuts)
        {
            Debug.LogWarning("Das Inventar ist voll.");
            return;
        }else{
            NumberOfNuts++;
            OnNutCollected.Invoke(this);
            // Soundeffekt abspielen
            AudioManager.instance.PlaySFX(collect_nut);
        } 
    }
}
