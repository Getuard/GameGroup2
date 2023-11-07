using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class manages a series of waypoints, providing functionality to retrieve and cycle through them.
public class WaypointPath : MonoBehaviour
{
    // Retrieves the waypoint at the specified index.
    public Transform GetWaypoint(int waypointIndex)
    {
        return transform.GetChild(waypointIndex);
    }

    // Calculates and returns the index of the next waypoint in the path, looping back if at the end.
    public int GetNextWaypointIndex(int currentWaypointIndex)
    {
        // Increment the waypoint index.
        int nextWaypointIndex = currentWaypointIndex + 1;

        // Loop back to the first waypoint if we've reached the end of the list.
        if (nextWaypointIndex == transform.childCount)
        {
            nextWaypointIndex = 0;
        }

        return nextWaypointIndex;
    }
}
