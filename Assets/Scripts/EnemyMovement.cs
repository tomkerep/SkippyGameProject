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

    private Vector3 previousPosition;
    private bool isMoving;


    public UnityEngine.AI.NavMeshAgent agent;
    public Animator animator;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent.updateRotation = false;

        originalPatrolSpeed = patrolSpeed;

        previousPosition = transform.position;

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

    UpdateAnimation();
       
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
      animator.SetBool("isChasing", true);
        chaseTimer = 0f;
    }

    void EndChase()
    {
        isChasing = false;
       animator.SetBool("isChasing", false);
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
    
    void UpdateAnimation()
    {
        Vector3 movementDirection = transform.position - previousPosition;
        movementDirection.y = 0f; // Ignore vertical movement
        isMoving = movementDirection.magnitude > 0.01f;

        animator.SetBool("isMoving", isMoving);

        if (isMoving)
        {
            // Calculate rotation angle from movement direction
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection);
            float angle = Quaternion.Angle(transform.rotation, targetRotation);

            // Update animator parameter based on angle (assuming you have a parameter named "TurnAngle")
            //animator.SetFloat("TurnAngle", angle);

            // Debug rotation angle and movement direction
           //Debug.Log("Rotation Angle: " + angle);
            // Debug.Log("Movement Direction: " + movementDirection);

            if(movementDirection.x > 0)
            {
                animator.SetBool("läuftRechts", true);
            }
            else
            {
                animator.SetBool("läuftRechts", false);
            }
           

            // Update previous position
            previousPosition = transform.position;
        }
    }


}
