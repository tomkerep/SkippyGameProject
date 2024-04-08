using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject Player;
    public GameObject NutText;
    public Transform respawnPoint;

    private void OnCollisionEnter(Collision other)
    {
        PlayerInventory playerInventory = other.gameObject.GetComponent<PlayerInventory>();
        InventoryUI inventory = NutText.GetComponent<InventoryUI>();

        if (other.gameObject.CompareTag("Player"))
        {
            playerInventory.NumberOfNuts = 0;
            Player.transform.position = respawnPoint.position;

            inventory.UpdateNutText(playerInventory); 
            
        }
    }
}
