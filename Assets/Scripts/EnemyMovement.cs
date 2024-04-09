using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
    public Transform[] waypoints;
    public float patrolSpeed = 1.5f; // Reduziere die Patrouillengeschwindigkeit
    public float chaseSpeed = 5f; // Erhöhe die Verfolgungsgeschwindigkeit
    public float chaseRadius = 3.5f;
    public float chaseDuration = 5f; // Verlängere die Verfolgungsdauer

    private Transform player;
    private int currentWaypointIndex = 0;
    private bool isChasing = false;
    private float chaseTimer = 0f;
    private float originalPatrolSpeed;

    public UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent.updateRotation = false;

        originalPatrolSpeed = patrolSpeed;
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
        agent.speed = patrolSpeed; // Setze die Geschwindigkeit des NavMeshAgent entsprechend der Patrouillengeschwindigkeit

        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }

        if (Vector3.Distance(transform.position, player.position) < chaseRadius)
        {
            StartChase();
        }
        else
        {
            agent.SetDestination(waypoints[currentWaypointIndex].position);
        }
    }

    void Chase()
    {
        agent.speed = chaseSpeed; // Setze die Geschwindigkeit des NavMeshAgent entsprechend der Verfolgungsgeschwindigkeit

        agent.SetDestination(player.position);

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
        yield return new WaitForSeconds(1f);

        agent.isStopped = false;
        agent.ResetPath();

        agent.speed = patrolSpeed;

        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;

        Patrol();
    }
}
