using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_3 : Enemy
{
    void Start()
    {
        FindPlayer();
    }

    void Update()
    {
        MoveToPlayer();
    }
}
