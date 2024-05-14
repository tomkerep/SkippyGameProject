using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject Player;
    public GameObject NutText;
    public Transform respawnPoint;
    public AudioClip hit_sound;

    private void OnCollisionEnter(Collision other)
    {
        PlayerInventory playerInventory = other.gameObject.GetComponent<PlayerInventory>();
        InventoryUI inventory = NutText.GetComponent<InventoryUI>();

        if (other.gameObject.CompareTag("Player"))
        {
            playerInventory.NumberOfNuts = 0;
            Player.transform.position = respawnPoint.position;
            // Soundeffekt abspielen
            AudioManager.instance.PlaySFX(hit_sound);

            inventory.UpdateNutText(playerInventory); 
            
        }
    }
}
