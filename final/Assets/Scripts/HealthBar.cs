using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

    public Transform lookForward;

    private Image image;
    private Health health;
    private float maxHealth;

    void Awake()
    {
        image = gameObject.GetComponentInChildren<Image>();
        health = gameObject.GetComponentInParent<Health>();
    }

    void Start()
    {
        maxHealth = health.HealthPoints;
    }

    // Update is called once per frame
    void Update()
    {
        image.fillAmount = health.HealthPoints / maxHealth;
        transform.LookAt(lookForward);
    }
}
