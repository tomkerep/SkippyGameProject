using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Door : MonoBehaviour
{
    public GameObject key; // Das Schlüssel-GameObject
    public GameObject doorClosed; // Das GameObject für die geschlossene Tür
    public GameObject doorOpen; // Das GameObject für die offene Tür

    void Start()
    {
        // Überprüfe, ob das Schlüssel-GameObject vorhanden ist
        if (key == null)
        {
            Debug.LogWarning("Key GameObject not assigned to the door!");
        }
    }

    void Update()
    {
        // Überprüfe, ob der Schlüssel aufgenommen wurde und die Tür geschlossen ist
        if (key != null && !key.activeSelf && doorClosed.activeSelf)
        {
            OpenDoor();
        }
    }

    void OpenDoor()
    {
        doorClosed.SetActive(false); // Deaktiviere die geschlossene Tür
        doorOpen.SetActive(true); // Aktiviere die offene Tür
    }
}


