using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Key : MonoBehaviour
{
    public UnityEvent onKeyPickedUp; // Ereignis, das ausgelöst wird, wenn der Schlüssel aufgenommen wird

    public GameObject door; // Referenz auf das Door-Skript

    public GameObject player; // Referenz auf das Player-Spielobjekt
    public float pickupDistance = 2f; // Die maximale Entfernung, in der der Spieler den Schlüssel aufnehmen kann

    private bool isPickedUp = false;

    void Update()
    {
        // Überprüfe, ob der Spieler in Reichweite ist, um den Schlüssel automatisch aufzunehmen
        if (!isPickedUp && Vector3.Distance(transform.position, player.transform.position) <= pickupDistance)
        {
            PickUpKey();
        }
    }

    void PickUpKey()
    {
        // Füge hier deine Logik hinzu, um den Schlüssel aufzunehmen
        // Zum Beispiel: Ändere das Sprite, deaktiviere das GameObject, etc.

        // Beispiel: Deaktiviere das GameObject
        gameObject.SetActive(false);
        isPickedUp = true;

        // Auslösen des Ereignisses, dass der Schlüssel aufgenommen wurde
        onKeyPickedUp.Invoke();
    }
}
