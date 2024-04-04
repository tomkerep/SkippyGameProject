using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Nut_new : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

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
            }
        }
    }
}
