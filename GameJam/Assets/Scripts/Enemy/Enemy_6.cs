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
        health = 6;
        color = new Color(212, 19, 253);
        delay = delayTime;
    }

    void Update()
    {
        if (delay > 0) delay -= Time.deltaTime;
        else
        {
            Instantiate(triangle, transform.position, transform.rotation);
            delay = delayTime;
        }

        MoveToPlayer();
    }
}
