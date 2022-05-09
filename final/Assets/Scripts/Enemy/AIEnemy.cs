using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIEnemy : MonoBehaviour
{
    public enum ENEMY_STATE { IDLE, PATROL, CHASE, ATTACK };

    public Transform player;
    public Transform[] wayPoints;
    public float sphereRadius = 5f;
    public float viewRadius = 10f;


    //Enemy spawns on first wayPoint location
    int wayPointIndex = 1;
    Animation anim;
    NavMeshAgent agent;
    ENEMY_STATE state;
    RaycastHit hit;
    LayerMask mask;
    bool isClose;
    bool seePlayer;
    bool view;


    void Awake()
    {
        anim = gameObject.GetComponent<Animation>();
        agent = gameObject.GetComponent<NavMeshAgent>();
        mask = LayerMask.GetMask("Player");
        state = ENEMY_STATE.PATROL;
    }

    void Start()
    {
        Patrol();
    }

    void Update()
    {
        Collider[] playerInView = Physics.OverlapSphere(transform.position, viewRadius, mask);
        print(playerInView.Length);
        if (playerInView.Length >= 1)
        {
            Vector3 dir = (player.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dir) < 90 / 2)
                seePlayer = true;
            else
                seePlayer = false;
        }
        isClose = Physics.OverlapSphere(transform.position, sphereRadius, mask).Length >= 1;
        switch (state)
        {
            case ENEMY_STATE.PATROL:
                Patrol();
                break;
            case ENEMY_STATE.CHASE:
                Chase();
                break;
            case ENEMY_STATE.ATTACK:
                Attack();
                break;
        }
        updateAnimation();
    }
    void Patrol()
    {
        if (seePlayer)
            state = ENEMY_STATE.CHASE;
      
        if (state == ENEMY_STATE.PATROL)
        {
            if (agent.remainingDistance < .5f)
            {
                updateWayPointIndex();
                transform.LookAt(wayPoints[wayPointIndex].position);
                agent.SetDestination(wayPoints[wayPointIndex].position);
            } else if (agent.pathPending)
            {
                return;
            } else
            {
                transform.LookAt(wayPoints[wayPointIndex].position);
                agent.SetDestination(wayPoints[wayPointIndex].position);
            }
        }
       

    }
    void Chase()
    {
        if (isClose)
            state = ENEMY_STATE.ATTACK;
        if (state == ENEMY_STATE.CHASE)
        {
            if (seePlayer)
            {
                //if (Vector3.Distance(transform.position, player.position) >= 6.5f)
                //{
                //    agent.isStopped = true;
                //}
                transform.LookAt(player.position);
                agent.SetDestination(player.position);
                agent.speed = 3;
            }
            else
            {
                state = ENEMY_STATE.PATROL;
                agent.speed = 1;
            }
        }
    }
    void Attack()
    {
        if (!isClose)
        {
            state = ENEMY_STATE.CHASE;
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

    void updateAnimation()
    {
        switch (state)
        {
            case ENEMY_STATE.IDLE:
                anim.Play("Idle");
                break;
            case ENEMY_STATE.PATROL:
                anim.Play("Walk");
                break;
            case ENEMY_STATE.CHASE:
                anim.Play("Run");
                break;
            case ENEMY_STATE.ATTACK:
                anim.Play("Attack1");
                break;
      
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, viewRadius);
    }
}
