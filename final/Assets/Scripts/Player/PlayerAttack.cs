using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float maxDamage = 15f;

    private void OnTriggerStay(Collider other)
    {
        bool attack = Input.GetButton("Fire1");

        GameObject enemy = other.gameObject;
        if (enemy.tag == "Enemy" && enemy.GetComponentInParent<Health>() != null && attack)
        {
            Health health = enemy.GetComponentInParent<Health>();
            health.HealthPoints -= maxDamage * Time.deltaTime;
        }
    }
}