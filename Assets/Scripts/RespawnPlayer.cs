using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    //public GameObject Player;
    public GameObject NutText;
    public Transform respawnPoint;
    public AudioClip hit_sound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerInventory playerInventory = other.gameObject.GetComponent<PlayerInventory>();
            InventoryUI inventory = NutText.GetComponent<InventoryUI>();

            Rigidbody playerRigidbody = other.gameObject.GetComponent<Rigidbody>();

            if (playerRigidbody != null)
            {
                // Disable the Rigidbody temporarily
                playerRigidbody.isKinematic = true;
                playerRigidbody.detectCollisions = false;

                // Directly set the player's position
                other.transform.position = respawnPoint.position;

                // Re-enable the Rigidbody
                playerRigidbody.isKinematic = false;
                playerRigidbody.detectCollisions = true;

                // Reset the Rigidbody's velocity to prevent any lingering movement
                playerRigidbody.velocity = Vector3.zero;
                playerRigidbody.angularVelocity = Vector3.zero;

                // Debugging lines
                Debug.Log("Player respawn position set to: " + respawnPoint.position);
                Debug.Log("Player current position: " + playerRigidbody.position);
            }
            else
            {
                Debug.LogWarning("Player does not have a Rigidbody component.");
            }

            playerInventory.NumberOfNuts = 0;
            //Player.transform.position = respawnPoint.position;
            // Soundeffekt abspielen
            AudioManager.instance.PlaySFX(hit_sound);

            inventory.UpdateNutText(playerInventory);

        }
    }
}
