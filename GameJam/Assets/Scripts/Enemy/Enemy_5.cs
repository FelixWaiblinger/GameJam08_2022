using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_5 : Enemy {


    void Start() {
        FindPlayer();
        FindEnemyTypes();
        FindComboEvent();
        startHealth = 5;
        currentHealth = startHealth;
        color = new Color(255, 132, 14);
    }
    
    void Update() {
        if (activateTimer < 0)
            col.enabled = true;
        else
            activateTimer -= Time.deltaTime;
            
        MoveToPlayer();
    }

    public override void TakeDamage(int dmg)
    {
        Instantiate(spawner.getEnemyTypes()[0], transform.position, transform.rotation);
        Die();
    }
}
