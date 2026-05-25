using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class ZombieAI : MonoBehaviour
{
    public Transform player;          // Player reference
    private NavMeshAgent agent;       // NavMesh agent

    public float updateDelay = 0.3f;  // Time between path updates
    public float chaseDistance = 30f; // Distance at which zombie starts chasing

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Start updating the path periodically
        StartCoroutine(UpdatePath());
    }

    IEnumerator UpdatePath()
    {
        while (true)
        {
            if (player != null)
            {
                float distance = Vector3.Distance(transform.position, player.position);

                // Only chase if player is close enough
                if (distance < chaseDistance)
                {
                    agent.SetDestination(player.position);
                }
                else
                {
                    agent.ResetPath(); // Stop moving if player is far
                }
            }

            yield return new WaitForSeconds(updateDelay);
        }
    }
}