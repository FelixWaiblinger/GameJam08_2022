using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected Transform player;
    [SerializeField] protected float movementSpeed = 1f;
    
    protected float health;

    protected void FindPlayer()
    {
        player = GameObject.Find("Player").transform;
    }

    protected void MoveToPlayer()
    {
        transform.position = Vector3.MoveTowards(
                                transform.position,
                                player.position,
                                movementSpeed * Time.deltaTime);
    }
}
