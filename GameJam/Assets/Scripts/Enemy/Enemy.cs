using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected Transform player;
    [SerializeField] protected Spawner spawner;
    [SerializeField] protected float movementSpeed = 1f;
    [SerializeField] protected GameObject splash;
    [SerializeField] protected GameObject explosion;
    
    protected int health;

    protected void FindPlayer()
    {
        player = GameObject.Find("Player").transform;
    }

    protected void FindEnemyTypes()
    {
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
    }

    protected void MoveToPlayer()
    {
        transform.position = Vector3.MoveTowards(
                                transform.position,
                                player.position,
                                movementSpeed * Time.deltaTime);
    }

    public void TakeDamage(int dmg)
    {
        switch (health - dmg)
        {
            case 4:
                Instantiate(spawner.getEnemyTypes()[1], transform.position, transform.rotation);
                break;

            case 3:
                Instantiate(spawner.getEnemyTypes()[0], transform.position, transform.rotation);
                break;
        }

        Destroy(gameObject);
        Instantiate(splash, transform.position, transform.rotation);
        Instantiate(explosion, transform.position, transform.rotation);
    }
}
