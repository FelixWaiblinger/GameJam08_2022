using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_4 : Enemy
{
    [SerializeField] private float delayTime = 2f;
    [SerializeField] private float speedUpTime = 0.5f;

    private float delay, speedUp;

    void Start()
    {
        FindPlayer();
        FindEnemyTypes();
        FindComboEvent();
        startHealth = 4;
        currentHealth = startHealth;
        color = new Color(73, 48, 254);
        delay = delayTime;
        speedUp = speedUpTime;
    }

    void Update()
    {
        if (activateTimer < 0)
            col.enabled = true;
        else
            activateTimer -= Time.deltaTime;

        if (delay > 0) delay -= Time.deltaTime;
        else
        {
            movementSpeed = 2f;

            if (speedUp > 0) speedUp -= Time.deltaTime;
            else
            {
                delay = delayTime;
                speedUp = speedUpTime;
                movementSpeed = 1f;
            }
        }

        MoveToPlayer();
    }

    public override void TakeDamage(int dmg)
    {
        Die();
    }
}
