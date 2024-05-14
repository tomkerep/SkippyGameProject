using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BauInventory : MonoBehaviour
{
    public GameObject NutText;
    public GameObject BauText;
    public GameObject GameWonScreen;

    public int StoredNuts {get; set;}
    
    public UnityEvent<BauInventory> OnNutsStored; 
    public AudioClip drop_nut;

    void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.gameObject.GetComponent<PlayerInventory>();
        InventoryUI inventoryUI = NutText.GetComponent<InventoryUI>();
    
        if(playerInventory != null){
        placeNuts(playerInventory.NumberOfNuts);
        // Soundeffekt abspielen
            AudioManager.instance.PlaySFX(drop_nut);
        playerInventory.NumberOfNuts = 0;
        inventoryUI.UpdateNutText(playerInventory);
        
        }
    }

    void placeNuts(int nutCount){
        
        BauInventoryUI bauInventoryUI = BauText.GetComponent<BauInventoryUI>();
        GameWonScreen gameWonScreen = GameWonScreen.GetComponent<GameWonScreen>();

        StoredNuts += nutCount;
        OnNutsStored.Invoke(this);
        bauInventoryUI.UpdateStars(this);
        //gameWonScreen.UpdateStars(this);

    
    }
}

