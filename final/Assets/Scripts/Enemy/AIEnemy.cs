using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIEnemy : MonoBehaviour
{
    public enum ENEMY_STATE { IDLE, PATROL, CHASE, ATTACK };

    public Transform player;
    public Transform[] wayPoints;
    public float attackRadius = 5f;
    public float viewRadius = 10f;
    public ENEMY_STATE state;


    //Enemy spawns on first wayPoint location
    int wayPointIndex = 1;
    Health health;
    Animation anim;
    NavMeshAgent agent;
    RaycastHit hit;
    LayerMask mask;
    bool isClose;
    bool seePlayer;


    void Awake()
    {
        anim = gameObject.GetComponent<Animation>();
        agent = gameObject.GetComponent<NavMeshAgent>();
        mask = LayerMask.GetMask("Player");
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        state = ENEMY_STATE.PATROL;
    }

    void Start()
    {
        Patrol();
    }

    void Update()
    {
        if (player != null)
        {
            Collider[] playerInView = Physics.OverlapSphere(transform.position, viewRadius, mask);
            if (playerInView.Length >= 1)
            {
                Vector3 dir = (player.position - transform.position).normalized;
                if (Vector3.Angle(transform.forward, dir) < 90 / 2)
                    seePlayer = true;
                else
                    seePlayer = false;
            }
            isClose = Physics.OverlapSphere(transform.position, attackRadius, mask).Length >= 1;
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
        }
        else
            state = ENEMY_STATE.IDLE;
         updateAnimation();
    }
    void Patrol()
    {
        if (seePlayer && Vector3.Distance(transform.position, player.position) <= 10f)
            state = ENEMY_STATE.CHASE;
      
        if (state == ENEMY_STATE.PATROL)
        {
            if (agent.remainingDistance < .5f)
            {
                updateWayPointIndex();
                transform.LookAt(wayPoints[wayPointIndex].position);
                agent.SetDestination(wayPoints[wayPointIndex].position);
            } else if (agent.pathPending) {
                return;
            } else {
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
            if (seePlayer && Vector3.Distance(transform.position, player.position) <= 10f)
            {
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
