using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject nussPrefab;
    public Transform[] spawnPoints;

    public void SpawnBullet()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            Instantiate(nussPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}

