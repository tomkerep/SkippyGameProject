using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject Player;
    public GameObject NutText;
    public Transform respawnPoint;
    public AudioClip hit_sound;
    //public GameObject PostProcessingGO;
    public TakeDamage takeDamage;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
        PlayerInventory playerInventory = other.gameObject.GetComponent<PlayerInventory>();
        InventoryUI inventory = NutText.GetComponent<InventoryUI>();
        //TakeDamage takeDamage = PostProcessingGO.GetComponent<TakeDamage>();

         StartCoroutine(takeDamage.TakeDamageEffect());
            playerInventory.NumberOfNuts = 0;
            Player.transform.position = respawnPoint.position;
            // Soundeffekt abspielen
            AudioManager.instance.PlaySFX(hit_sound);

            inventory.UpdateNutText(playerInventory); 

            
            
        }
    }
}
