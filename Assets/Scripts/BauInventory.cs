using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BauInventory : MonoBehaviour
{
    public GameObject NutText;
    public int StoredNuts {get; set;}
    
    public UnityEvent<BauInventory> OnNutsStored; 

    void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.gameObject.GetComponent<PlayerInventory>();
        InventoryUI inventoryUI = NutText.GetComponent<InventoryUI>();

        if(playerInventory != null){
        placeNuts(playerInventory.NumberOfNuts);
        playerInventory.NumberOfNuts = 0;
        inventoryUI.UpdateNutText(playerInventory);
        }
    }

    void placeNuts(int nutCount){
        
        StoredNuts += nutCount;
        OnNutsStored.Invoke(this);
        Debug.LogWarning("Nüsse wurden abgelegt"+ StoredNuts);
 
    }
}

