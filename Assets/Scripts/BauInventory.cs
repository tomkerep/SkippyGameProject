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
    void Start()
        {
            // Überprüfe, ob der AudioClip im Inspector zugewiesen wurde
            if (drop_nut == null)
            {
                Debug.LogError("drop_nut AudioClip ist nicht zugewiesen!");
            }
        }
    void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.gameObject.GetComponent<PlayerInventory>();
        InventoryUI inventoryUI = NutText.GetComponent<InventoryUI>();
    
        if(playerInventory != null)
        {
            placeNuts(playerInventory.NumberOfNuts);
            // Soundeffekt abspielen
            if (AudioManager.instance != null)
                {
                    if (drop_nut != null)
                {
                    Debug.Log("Playing SFX: drop_nut");
                    AudioManager.instance.PlaySFX(drop_nut);
                }
                else
                {
                    Debug.LogError("drop_nut AudioClip ist null!");
                }
            }
            else
            {
                Debug.LogError("AudioManager instance is null!");
            }
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

