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
        color = new Color(43, 66, 55);
    }

    void Update()
    {
        MoveToPlayer();
    }
}
