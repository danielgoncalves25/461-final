using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIEnemy : MonoBehaviour
{
    public enum ENEMY_STATE { PATROL, CHASE, ATTACK };

    public bool isPatrolling;
    public Transform player;
    public Transform[] wayPoints;
    public Transform eyes;


    //Enemy spawns on first wayPoint location
    int wayPointIndex = 1;
    Animation anim;
    NavMeshAgent agent;
    ENEMY_STATE state;
    RaycastHit hit;
    LayerMask mask;



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
        Debug.DrawRay(eyes.position, eyes.TransformDirection(Vector3.forward) * 50, Color.red);
        bool seePlayer = Physics.Raycast(eyes.position, eyes.TransformDirection(Vector3.forward) * 50, out hit, Mathf.Infinity, mask);
        //if (Physics.Raycast(eyes.position, eyes.TransformDirection(Vector3.forward) * 50, out hit, Mathf.Infinity, mask))
        //{
        //    Debug.Log("I SEE U");
        }
        if (Physics.OverlapSphere(transform.position, 7, mask).Length >= 1)
        {
            Debug.Log("YOU ARE CLOSE");
        }
        if (state == ENEMY_STATE.PATROL && agent.remainingDistance < 1f)
        {
            updateWayPointIndex();
            Patrol();
        } else if (seePlayer) {
            Chase();
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
        state = ENEMY_STATE.PATROL;
        transform.LookAt(wayPoints[wayPointIndex].position);
        agent.SetDestination(wayPoints[wayPointIndex].position);

    }
    void Chase()
    {
        state = ENEMY_STATE.CHASE;
        agent.SetDestination(player.position);
    }
void Attack()
    {

    }
    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 7);
    }
}
