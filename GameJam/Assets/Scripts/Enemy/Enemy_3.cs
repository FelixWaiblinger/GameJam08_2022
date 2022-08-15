using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_3 : Enemy
{
    void Start()
    {
        FindPlayer();
        FindEnemyTypes();
        FindComboEvent();
        health = 3;
        color = new Color(201, 19, 12);
    }

    void Update()
    {
        if (activateTimer < 0)
            col.enabled = true;
        else
            activateTimer -= Time.deltaTime;
            
        MoveToPlayer();
    }
}
