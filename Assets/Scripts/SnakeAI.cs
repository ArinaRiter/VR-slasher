using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using Random = UnityEngine.Random;
using UnityEngine.AI;


public class SnakeAI : MonoBehaviour
{

    List<Transform> points = new List<Transform>();
    NavMeshAgent agent;
    [SerializeField] private Animator animator;
    private Player _player;
    private int count = 9;
    public bool _killRat;
    private float _distance;
    void Start()
    {
        _player = GameObject.FindObjectOfType<Player>();
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
        if (_killRat)
        {
            agent.SetDestination(_player.transform.position);
            _distance =  Vector3.Distance(gameObject.transform.position, _player.transform.position);
            if (_distance < 3)
            {
                gameObject.GetComponent<EnemyAnimator>().PlayAttack();
                _player.TakeDamage(100);
            }
        }
        else if (agent != null && agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.SetDestination(points[count].position);
            if (count < points.Count - 1)
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
