using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseBehaviour : StateMachineBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;
    Transform player;
    float attackRange = 4;
    float ChaseRange = 10;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.speed = 4;
        player = GameObject.FindGameObjectWithTag("player").transform;
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //agent.SetDestination(player.position);
        agent.destination = player.position;
        float distance = Vector3.Distance(animator.transform.position, player.position);
        if (distance < attackRange)
        {
            animator.SetBool("isAttacking", true);

        }
        if (distance > ChaseRange)
        {
            animator.SetBool("isChasing", false);
        }
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
        agent.speed = 2;
    }
}
