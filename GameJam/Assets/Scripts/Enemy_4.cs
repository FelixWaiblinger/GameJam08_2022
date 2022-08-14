using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_4 : Enemy
{
    [SerializeField] private float speedUpTime = 2.5f;

    private float timer;

    void Start()
    {
        FindPlayer();
        timer = speedUpTime;
    }

    void Update()
    {
        if (timer > 0) timer -= Time.deltaTime;
        else
        {
            movementSpeed *= 5;
            timer = speedUpTime;
        }

        MoveToPlayer();

        movementSpeed = 1f;
    }
}
