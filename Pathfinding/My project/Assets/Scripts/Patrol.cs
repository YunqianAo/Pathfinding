using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class Patrol : MonoBehaviour
{
    public Transform[] points;
    private NavMeshAgent agent;

    private List<Transform> remainingPoints;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;

        ResetRemainingPoints();
        GotoNextPoint();
    }

    void ResetRemainingPoints()
    {
        remainingPoints = new List<Transform>(points);
    }

    void GotoNextPoint()
    {
        if (remainingPoints.Count == 0)
        {
            ResetRemainingPoints();
        }

        int randomIndex = Random.Range(0, remainingPoints.Count);
        Transform nextPoint = remainingPoints[randomIndex];

        agent.destination = nextPoint.position;

        remainingPoints.RemoveAt(randomIndex);
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }
}
