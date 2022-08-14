using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_4 : Enemy
{
    [SerializeField] private float delayTime = 2f;
    [SerializeField] private float speedUpTime = 0.5f;

    private float delay, speedUp;
    private Color color = new Color(73, 48, 254);

    void Start()
    {
        FindPlayer();
        health = 4;
        delay = delayTime;
        speedUp = speedUpTime;
    }

    void Update()
    {
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
}
