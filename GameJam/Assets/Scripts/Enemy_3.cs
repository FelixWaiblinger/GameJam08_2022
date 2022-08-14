using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_3 : Enemy
{
    [SerializeField] private Transform player;
    [SerializeField] private float movementSpeed = 1f;

    void Start()
    {
        FindPlayer();
    }

    void Update()
    {
        MoveToPlayer();
    }
}
