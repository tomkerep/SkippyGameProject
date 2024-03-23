using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] waypoints; // Array to hold the waypoints
    public float patrolSpeed = 3f; // Speed at which the NPC moves while patrolling
    public float chaseSpeed = 5f; // Speed at which the NPC moves while chasing the player
    public float chaseRadius = 5f; // Radius within which the NPC starts chasing the player
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
        // Move NPC towards the current waypoint
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, patrolSpeed * Time.deltaTime);

        // Check if NPC has reached the current waypoint
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
        {
            // Move to the next waypoint
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }

        // Check if the player is within the chase radius
        if (Vector3.Distance(transform.position, player.position) < chaseRadius)
        {
            StartChase();
        }
    }

    void Chase()
    {
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
    }
}
