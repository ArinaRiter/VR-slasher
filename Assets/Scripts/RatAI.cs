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
    List<Transform> points2 = new List<Transform>();
    NavMeshAgent agent;
    [SerializeField] private Animator animator;

    public bool _killSnake;

    [SerializeField] GameObject point1;
    [SerializeField] GameObject point2;

    private bool countzero = false;

    private int count = 0;
    void Start()
    {
        PointSet();
        agent.SetDestination(points[0].position);
        //agent = animator.GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        if (_killSnake && (agent != null && agent.remainingDistance <= agent.stoppingDistance))
        {
            if (!countzero)
            {           
                count = 0;
                countzero = true;
            }
            point1.SetActive(false);
            //point2.SetActive(true);

            //PointSet();
            Debug.Log(points2.Count);
            //agent = animator.GetComponent<NavMeshAgent>();
            agent.SetDestination(points2[count].position);
            Debug.Log(count + " count");
            //agent.SetDestination(points2[0].position);
            if (count < points2.Count - 1)
            {
                count++;
            }
            else
            {
                Destroy(GameObject.FindWithTag("Rat"));
            }

        }
        else if (agent != null && agent.remainingDistance <= agent.stoppingDistance)
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

    private void PointSet()
    {
        Transform pointsObjects = GameObject.FindGameObjectWithTag("Point").transform;
        foreach (Transform t in pointsObjects)
        {
            points.Add(t);
            Debug.Log("lol");
        }
        agent = animator.GetComponent<NavMeshAgent>();

        Transform points2Objects = GameObject.FindGameObjectWithTag("WayPoints").transform;
        foreach (Transform t in points2Objects)
        {
            points2.Add(t);
            Debug.Log(points2.Count);
        }
    }


}
