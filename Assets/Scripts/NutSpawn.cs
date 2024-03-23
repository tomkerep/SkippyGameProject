using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutSpawn : MonoBehaviour
{

 public GameObject nussPrefab;
    public Transform[] spawnPoints;
    public float spawnInterval = 2f; // Adjust as needed

    // Update is called once per frame
    void Update()
    {
        
    }


    private void Start()
    {
        // Start spawning bullets after a delay
        StartCoroutine(SpawnBulletRoutine());
    }

    private System.Collections.IEnumerator SpawnBulletRoutine()
    {
        // Keep spawning bullets indefinitely
        while (true)
        {
            // Wait for the specified spawn interval
            yield return new WaitForSeconds(spawnInterval);

            // Randomly select a spawn point index
            int randomSpawnIndex = Random.Range(0, spawnPoints.Length);

            // Get the position of the randomly selected spawn point
            Vector3 spawnPosition = spawnPoints[randomSpawnIndex].position;
            Quaternion spawnRotation = spawnPoints[randomSpawnIndex].rotation;

            // Spawn the bullet at the selected spawn point
            Instantiate(nussPrefab, spawnPosition, spawnRotation);
        }
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
}*/

