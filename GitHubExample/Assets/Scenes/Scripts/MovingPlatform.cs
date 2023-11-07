using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls a platform moving along a specified path of waypoints at a set speed.
public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private WaypointPath _waypointPath; // Holds the path data for the platform to follow.

    [SerializeField]
    private float _speed; // Movement speed of the platform between waypoints.

    private int _targetWaypointIndex; // Tracks the current target waypoint index in the path.

    private Transform _previousWaypoint; // Stores the last waypoint the platform has passed.
    private Transform _targetWaypoint; // Stores the next waypoint the platform is moving towards.

    private float _timeToWaypoint; // Time calculated to reach the next waypoint, considering speed.
    private float _elapsedTime; // Time that has already passed since starting towards the current waypoint.

    // Initializes the platform's movement towards the first waypoint.
    void Start()
    {
        TargetNextWaypoint();
    }

    // Moves the platform towards the current target waypoint and updates to the next one when reached.
    void FixedUpdate()
    {
        // Movement calculation using SmoothStep for smoother transitions.
        _elapsedTime += Time.deltaTime;
        float elapsedPercentage = Mathf.SmoothStep(0, 1, _elapsedTime / _timeToWaypoint);
        transform.position = Vector3.Lerp(_previousWaypoint.position, _targetWaypoint.position, elapsedPercentage);
        transform.rotation = Quaternion.Lerp(_previousWaypoint.rotation, _targetWaypoint.rotation, elapsedPercentage);

        // Change to the next waypoint when the current one is reached.
        if (elapsedPercentage >= 1)
        {
            TargetNextWaypoint();
        }
    }

    // Sets the next waypoint as the new target and calculates the time required to reach it based on speed.
    private void TargetNextWaypoint()
    {
        _previousWaypoint = _waypointPath.GetWaypoint(_targetWaypointIndex);
        _targetWaypointIndex = _waypointPath.GetNextWaypointIndex(_targetWaypointIndex);
        _targetWaypoint = _waypointPath.GetWaypoint(_targetWaypointIndex);

        _elapsedTime = 0;
        _timeToWaypoint = Vector3.Distance(_previousWaypoint.position, _targetWaypoint.position) / _speed;
    }

    // Attaches/detaches objects to/from the platform upon collision to ensure they move with it.
    private void OnTriggerEnter(Collider other)
    {
        other.transform.SetParent(transform);
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
    }
}
