using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject player;
    public GameObject door;
    public float pickupDistance = 2f; // Die maximale Entfernung, in der der Spieler den Schlüssel aufnehmen kann

    private bool isPickedUp = false;

    void Update()
    {
        // Überprüfe, ob der Spieler in Reichweite ist, um den Schlüssel automatisch aufzunehmen
        if (!isPickedUp && Vector3.Distance(transform.position, player.transform.position) <= pickupDistance)
        {
            PickUpKey();
            OpenDoor();
        }
    }

    void PickUpKey()
    {
        // Füge hier deine Logik hinzu, um den Schlüssel aufzunehmen
        // Zum Beispiel: Ändere das Sprite, deaktiviere das GameObject, etc.

        // Beispiel: Deaktiviere das GameObject
        gameObject.SetActive(false);

        // Setze den Status "isPickedUp" auf true, um zu verhindern, dass der Schlüssel mehrmals aufgehoben wird
        isPickedUp = true;
    }

    void OpenDoor()
    {
        // Überprüfe, ob die Tür existiert und öffne sie, wenn ja
        if (door != null)
        {
            door.SetActive(false); // Deaktiviere die Tür zu
            // Hier kannst du weitere Logik einfügen, um die Tür offen anzuzeigen
        }
    }
}
