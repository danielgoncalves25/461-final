using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    float maxDamage = 5f;
    Health health;
    AIEnemy obj;

    void Awake()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        obj = GameObject.FindGameObjectWithTag("Enemy").GetComponent<AIEnemy>();

    }

    void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
        if (collision.gameObject.tag == "Player" && obj.state.ToString() == "ATTACK")
        {
            health.HealthPoints -= maxDamage;
        }
    }
}
