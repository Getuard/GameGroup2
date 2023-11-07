using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform playerTransform;
    private NavMeshAgent agent;
    public float updateRate = 0.3f; // How often in seconds to update the destination.
    private float nextUpdateTime = 0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (playerTransform == null)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null)
            {
                playerTransform = playerObject.transform;
            }
            else
            {
                Debug.LogError("Player transform is not assigned and the player cannot be found with 'Player' tag.");
            }
        }
    }


    void Update()
    {
        if (playerTransform != null && Time.time > nextUpdateTime)
        {
            // Only update the destination of the agent to the player's position if the player exists
            bool hasPath = agent.SetDestination(playerTransform.position);
            if (!hasPath)
            {
                Debug.LogWarning("EnemyAI: Failed to set destination.");
            }
            nextUpdateTime = Time.time + updateRate; // Set the time for the next update.
        }
    }
}


