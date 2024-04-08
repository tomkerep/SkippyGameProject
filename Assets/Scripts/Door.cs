using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    public GameObject doorClosed; // Das GameObject für die geschlossene Tür
    public GameObject doorOpened; // Das GameObject für die offene Tür
    public float openDistance = 2f; // Die Entfernung, in der die Tür geöffnet werden kann

    private bool isKeyTaken = false; // Flag, das angibt, ob der Schlüssel genommen wurde

    private void Start()
    {
        doorClosed.SetActive(true);
        doorOpened.SetActive(false);
        // Überprüfe, ob das doorClosed GameObject zugewiesen wurde
        if (doorClosed == null)
        {
            Debug.LogWarning("doorClosed GameObject not assigned to the door!");
        }

        // Überprüfe, ob das doorOpened GameObject zugewiesen wurde
        if (doorOpened == null)
        {
            Debug.LogWarning("doorOpened GameObject not assigned to the door!");
        }
    }

    public void UpdateKeyStatus()
    {
        isKeyTaken = true;
    }

    public void TryOpenDoor()
    {
        // Überprüfe, ob der Schlüssel genommen wurde und der Spieler in der Nähe der geschlossenen Tür ist
        if (isKeyTaken && doorClosed.activeSelf && Vector3.Distance(transform.position, doorClosed.transform.position) < openDistance)
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        // Deaktiviere die geschlossene Tür und aktiviere die offene Tür
        doorClosed.SetActive(false);
        doorOpened.SetActive(true);
        Debug.Log("Tür wird geöffnet!");
    }
}
