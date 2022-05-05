using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIEnemy : MonoBehaviour
{
    public bool isPatrolling; 
    public Transform[] wayPoints;

    //Enemy spawns on first wayPoint location
    int wayPointIndex = 1;
    Animation anim;
    NavMeshAgent agent;

    bool curPatroling = true;
    bool curChasing = false;
    bool curAttacking = false;

    void Awake()
    {
        anim = gameObject.GetComponent<Animation>();
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        Patrol();
    }

    void Update()
    {
        if (curPatroling && agent.remainingDistance < 1f)
        {
            updateWayPointIndex();
            Patrol();
        }

    }

    void updateWayPointIndex()
    {
        if (wayPointIndex == wayPoints.Length -1)
        {
            wayPointIndex = 0;
        } else {
            wayPointIndex++;
        }
    }
    void Patrol()
    {
        curPatroling = true;
        transform.LookAt(wayPoints[wayPointIndex].position);
        agent.SetDestination(wayPoints[wayPointIndex].position);

    }
    void Chase()
    {

    }
    void Attack()
    {

    }
}
