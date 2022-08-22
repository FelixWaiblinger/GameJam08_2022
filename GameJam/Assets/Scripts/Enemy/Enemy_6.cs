using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_6 : Enemy
{
    [SerializeField] private GameObject triangle;
    [SerializeField] private float delayTime = 5f;

    private float delay;

    void Start()
    {
        FindPlayer();
        FindEnemyTypes();
        FindComboEvent();
        startHealth = 6;
        currentHealth = startHealth;
        color = new Color(212, 19, 253);
        delay = delayTime;
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
            Instantiate(triangle, transform.position, transform.rotation);
            delay = delayTime;
        }

        MoveToPlayer();
    }

    public override void TakeDamage(int dmg)
    {
        Instantiate(spawner.getEnemyTypes()[1], transform.position, transform.rotation);
        Die();
    }
}
