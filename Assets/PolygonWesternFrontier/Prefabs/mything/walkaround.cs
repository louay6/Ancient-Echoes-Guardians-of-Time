using UnityEngine;
using UnityEngine.AI;

public class NPCRandomWalker : MonoBehaviour
{
    public float walkRadius = 10f; // Radius within which the NPC can walk
    public float walkInterval = 5f; // Interval between each walk

    private NavMeshAgent agent;
    private float timer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = walkInterval;

        // Start walking immediately
        WalkRandomly();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            WalkRandomly();
            timer = walkInterval; // Reset the timer
        }
    }

    void WalkRandomly()
    {
        // Get a random point within the walk radius
        Vector3 randomDirection = Random.insideUnitSphere * walkRadius;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, walkRadius, 1);
        Vector3 finalPosition = hit.position;

        // Move the agent to the random position
        agent.SetDestination(finalPosition);
    }
}
