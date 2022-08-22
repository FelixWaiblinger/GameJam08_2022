using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Boss_1 : Enemy {
    [SerializeField] private float delayTime = 6f;

    private float delay;

    void Start() {
        FindPlayer();
        FindEnemyTypes();
        FindComboEvent();
        startHealth = 14;
        currentHealth = startHealth;
        color = new Color(253, 19, 61);
        delay = delayTime;
    }

    void Update() {
        if (activateTimer < 0)
            col.enabled = true;
        else
            activateTimer -= Time.deltaTime;
            
        if (delay > 0) delay -= Time.deltaTime;
        else {
            transform.localScale += (new Vector3(0.5f, 0.5f, 1f));
            delay = delayTime;
        }

        MoveToPlayer();
    }

    public override void TakeDamage(int dmg)
    {
        currentHealth -= dmg;

        switch (currentHealth)
        {
            case 12:
                Instantiate(spawner.getEnemyTypes()[3], transform.position, transform.rotation);
                Instantiate(spawner.getEnemyTypes()[3], transform.position, transform.rotation);
                Instantiate(spawner.getEnemyTypes()[3], transform.position, transform.rotation);
                break;

            case 10:
                Instantiate(spawner.getEnemyTypes()[2], transform.position, transform.rotation);
                Instantiate(spawner.getEnemyTypes()[2], transform.position, transform.rotation);
                break;

            case 8:
                Instantiate(spawner.getEnemyTypes()[1], transform.position, transform.rotation);
                break;

            case 6:
            case 4:
                Instantiate(spawner.getEnemyTypes()[0], transform.position, transform.rotation);
                break;

            default:
                Die();
                break;
        }
    }
}
