using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using Random = UnityEngine.Random;
using UnityEngine.AI;


public class RatAI : MonoBehaviour
{
    private float timer;
    List<Transform> points = new List<Transform>();
    NavMeshAgent agent;
    [SerializeField] private Animator animator;

    private int count = 0;
    void Start()
    {

        Transform pointsObjects = GameObject.FindGameObjectWithTag("Point").transform;
        foreach (Transform t in pointsObjects)
        {
            points.Add(t);
        }
        agent = animator.GetComponent<NavMeshAgent>();
        agent.SetDestination(points[0].position);

    }

    private void Update()
    {
        if (agent != null && agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.SetDestination(points[count].position);
            if(count < points.Count-1)
            {
                count++;
            }
            else
            {
                count = 0;
            }
        }
    }
}
