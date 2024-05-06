using UnityEngine;

public class KeyController : MonoBehaviour
{
    public float pickupRadius = 3f; // Der Aufnahme-Radius für den Schlüssel
    public GameObject closedDoorSprite; // Das Sprite für die geschlossene Tür
    public GameObject openDoorSprite; // Das Sprite für die geöffnete Tür
    //public GameObject blockingObject; // Das 3D-Objekt, das den Weg blockiert


    private void Start()
    {
        openDoorSprite.SetActive(false);
        //blockingObject.SetActive(true);
    }
    private void Update()
    {
        // Überprüfen, ob der Spieler den Schlüssel berührt und innerhalb des Pickup-Radius ist
        if (IsPlayerInRange())
        {
            // Schlüssel aufheben
            PickUpKey();

            // Tür öffnen
            OpenDoor();
        }
    }

    // Überprüfen, ob der Spieler innerhalb des Pickup-Radius ist
    private bool IsPlayerInRange()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            return Vector3.Distance(transform.position, player.transform.position) <= pickupRadius;
        }
        return false;
    }

    // Methode zum Aufheben des Schlüssels (kann je nach Ihrem Spiel angepasst werden)
    private void PickUpKey()
    {
        // Hier können Sie die Logik zum Aufheben des Schlüssels implementieren
        // Zum Beispiel: Destroy(gameObject); // Zerstört das Schlüsselobjekt
        gameObject.SetActive(false); // Deaktiviert das Schlüsselobjekt
    }

    // Methode zum Öffnen der Tür
    private void OpenDoor()
    {
        // Aktivieren/deaktivieren Sie die entsprechenden Objekte, um die Tür zu öffnen
        closedDoorSprite.SetActive(false);
        openDoorSprite.SetActive(true);
        //blockingObject.SetActive(false); // Deaktivieren Sie das blockierende 3D-Objekt
    }
}
