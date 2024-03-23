using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [SerializeField] private Color waypointColor = Color.yellow; // Color to visualize the waypoint in the scene view

    void OnDrawGizmos()
    {
        // Draw a sphere gizmo to visualize the waypoint in the scene view
        Gizmos.color = waypointColor;
        Gizmos.DrawSphere(transform.position, 0.2f);
    }
}
