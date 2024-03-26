using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutSpawn : MonoBehaviour
{

public GameObject nussPrefab;
    public Transform[] spawnPoints;
    public float spawnInterval = 2f; // Adjust as needed

    private bool isSpawning = false; // Flag to prevent multiple coroutines
   
    private void Start()
    {
        // Start spawning bullets after a delay
        InvokeRepeating("SpawnBullet", 0f, spawnInterval);
    }

    private void SpawnBullet()
    {
        if (!isSpawning)
        {
            isSpawning = true;
            StartCoroutine(SpawnBulletRoutine());
        }
    }

    private System.Collections.IEnumerator SpawnBulletRoutine()
    {
        // Randomly select a spawn point index
        int randomSpawnIndex = Random.Range(0, spawnPoints.Length);

        // Get the position and rotation of the randomly selected spawn point
        Vector3 spawnPosition = spawnPoints[randomSpawnIndex].position;
        Quaternion spawnRotation = spawnPoints[randomSpawnIndex].rotation;

        // Check if there's already a nut at this spawn point
        if (!IsNutAtSpawnPoint(spawnPosition))
        {
            // Spawn the nut at the selected spawn point
            Instantiate(nussPrefab, spawnPosition, spawnRotation);
        }

        // Reset the spawning flag after the delay
        yield return new WaitForSeconds(spawnInterval);
        isSpawning = false;
    }

    private bool IsNutAtSpawnPoint(Vector3 spawnPosition)
    {
        // Check if there's any nut object within a small radius of the spawn point
        Collider[] colliders = Physics.OverlapSphere(spawnPosition, 0.5f); // Adjust radius as needed
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.CompareTag("Nut"))
            {
                return true; // Nut already exists at this spawn point
            }
        }
        return false; // No nut found at this spawn point
    }
}
/*
    public void Pickup()
    {
        // Hier kann die Logik für das Aufnehmen des Objekts implementiert werden
        Debug.Log("Object picked up!"); // Beispiel: Gib eine Nachricht aus, dass das Objekt aufgenommen wurde

        // Füge das aufgenommene Objekt zum Inventar des Spielers hinzu
        AddToPlayerInventory();

        // Deaktiviere das GameObject, um es unsichtbar zu machen
        gameObject.SetActive(false);
    }
}
/*
    private void AddToPlayerInventory()
    {
        // Annahme: Der Spieler hat ein Inventar, das als Inventar-Skript implementiert ist.
        // Wenn du noch kein Inventar-Skript hast, musst du es erstellen und hier verwenden.
        Inventory playerInventory = FindObjectOfType<Inventory>(); // Finde das Inventar-Skript im Spiel (du musst sicherstellen, dass es vorhanden ist)

        if (playerInventory != null)
        {
            // Füge das Objekt dem Inventar des Spielers hinzu
            playerInventory.AddItem(gameObject);
        }
        else
        {
            Debug.LogWarning("Player inventory not found!"); // Gib eine Warnung aus, wenn das Inventar nicht gefunden wurde
        }
    }
}
*/
