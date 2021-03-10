using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointController : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>(); // Our waypoints on level
    private Transform targetWaypoint; // Waypoint where player should movement
    private int targetWaypointIndex = 0; 
    private int lastWaypointIndex; // How much waypoints on level
    private float minDistance = 0.1f; // Distance
    [SerializeField] private float speed = 25.0f; // Speed movement
    [SerializeField] private float rotationSpeed = 5.0f;
    public List<int> Checkpoints = new List<int>();
    public static int currentCheckpoint = 0;

    public static bool inGame = false;

    void Start()
    {
        lastWaypointIndex = waypoints.Count - 1;
        targetWaypoint = waypoints[targetWaypointIndex]; // Starting waypoint where player should to go
    }

    void Update()
    {
        if (inGame == false)
        {
            return;
        }

        float movementStep = speed * Time.deltaTime; // Step movement
        float rotationStep = rotationSpeed * Time.deltaTime;

        Vector3 directionToTarget = targetWaypoint.position - transform.position;
        Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotationToTarget, rotationStep);

        Debug.DrawRay(transform.position, transform.forward * 50f, Color.green, 0f); //Draws a ray forward in the direction checkpoint is facing
        Debug.DrawRay(transform.position, directionToTarget, Color.red, 0f); //Draws a ray in the direction of the current target waypoint

        float distance = Vector3.Distance(transform.position, targetWaypoint.position);
        CheckDistanceToWaypoint(distance);

        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, movementStep);
    }

    // Checks to see if player is within distance of the waypoint. If it is, it called the UpdateTargetWaypoint function 
    void CheckDistanceToWaypoint(float currentDistance)
    {
        if (targetWaypointIndex < Checkpoints[currentCheckpoint])
        {
            if (currentDistance <= minDistance)
            {
                targetWaypointIndex++; // New waypoint index
                UpdateTargetWaypoint(); // Update waypoint to go index
            }
        }        
    }

    // Increaes the index of the target waypoint. If player has reached the last waypoint in the waypoints list, it resets the targetWaypointIndex to the first waypoint in the list
    void UpdateTargetWaypoint()
    {        
        targetWaypoint = waypoints[targetWaypointIndex]; // new waypoint position where player should to go
    }
}
