using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Nut_new : MonoBehaviour
{

    public int time;

    public GameObject NutText; 

    
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
        NutSpawn nutspawn = GetComponent<NutSpawn>();

        if(playerInventory != null)
        {
            if(playerInventory.NumberOfNuts >= playerInventory.MaxNumberOfNuts)
            {
                Debug.LogWarning("Das Inventar ist voll.");
                return;
            }else
            {
                playerInventory.NutCollected();
                gameObject.SetActive(false);
                Invoke("wakeup", time);
            }
        }
    }


    void wakeup()
    {
        gameObject.SetActive(true);
    }
}
