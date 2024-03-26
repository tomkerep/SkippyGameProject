using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] waypoints; // Array to hold the waypoints
    public float patrolSpeed = 3f; // Speed at which the NPC moves while patrolling
    public float chaseSpeed = 4.5f; // Speed at which the NPC moves while chasing the player
    public float chaseRadius = 3.5f; // Radius within which the NPC starts chasing the player
    public float chaseDuration = 2f; // Duration for which the NPC chases the player before returning to waypoint path

    private Transform player; // Reference to the player's transform
    private int currentWaypointIndex = 0; // Index of the current waypoint
    private bool isChasing = false; // Flag to indicate if NPC is currently chasing the player
    private float chaseTimer = 0f; // Timer for chase duration

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Find the player's transform
    }

    void Update()
    {
        if (waypoints.Length == 0)
        {
            Debug.LogWarning("No waypoints assigned to NPCMovement script.");
            return;
        }

        if (!isChasing)
        {
            Patrol();
        }
        else
        {
            Chase();
        }
    }

    void Patrol()
{
    // Berechne die Richtung zum aktuellen Wegpunkt
    Vector3 direction = waypoints[currentWaypointIndex].position - transform.position;
    direction.y = 0f; // Ignoriere die Höhenunterschiede

    // Überprüfe, ob ein Hindernis den Weg des Gegners blockiert
    if (Physics.Raycast(transform.position, direction, out RaycastHit hit, direction.magnitude))
    {
        // Wenn ein Hindernis erkannt wird, ändere die Richtung des Gegners nicht
        if (!hit.collider.CompareTag("Player")) // Ignoriere den Spieler, damit der Gegner den Spieler verfolgen kann, wenn er in Sichtweite ist
        {
            // Debug.Log("Obstacle detected. Changing direction.");
            return;
        }
    }

    // Bewege den NPC in Richtung des aktuellen Wegpunkts
    transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, patrolSpeed * Time.deltaTime);

    // Überprüfe, ob der NPC den aktuellen Wegpunkt erreicht hat
    if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
    {
        // Bewege den NPC zum nächsten Wegpunkt
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
    }

    // Überprüfe, ob der Spieler innerhalb des Verfolgungsradius ist
    if (Vector3.Distance(transform.position, player.position) < chaseRadius)
    {
        StartChase();
    }
}

    void Chase()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Check if player is out of chase radius
        if(distanceToPlayer > chaseRadius)
        {
            EndChase();
            return;
        }

        // Move NPC towards the player
        transform.position = Vector3.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);

        // Update chase timer
        chaseTimer += Time.deltaTime;
        if (chaseTimer >= chaseDuration)
        {
            EndChase();
        }
    }

    void StartChase()
    {
        isChasing = true;
        chaseTimer = 0f;
    }

    void EndChase()
{
    isChasing = false;
    StartCoroutine(ReturnToPatrol());
}

IEnumerator ReturnToPatrol()
{
    yield return new WaitForSeconds(1f); // Warte eine kurze Zeit, bevor der Gegner zur Patrouille zurückkehrt (optional)
    
    // Bewege den Gegner zum nächsten Wegpunkt in der Patrouille
    while (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) > 0.1f)
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, patrolSpeed * Time.deltaTime);
        yield return null;
    }

    // Setze den Index des aktuellen Wegpunkts auf den nächsten Wegpunkt in der Patrouille
    currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
}
}
