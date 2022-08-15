using System;
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
    [SerializeField] protected GameObject killNumber;
    [SerializeField] protected Collider2D col;
    
    protected int comboMultiplier = 1;
    protected Color color;
    protected int health;
    protected float activateTimer = 0.5f;

    public static event Action<int> killEvent;

    protected void FindComboEvent()
    {
        KillCounter.comboEvent += num => comboMultiplier = num;
    }

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

        killEvent(health);
        Destroy(gameObject);
        
        GameObject spl = Instantiate(splash, transform.position, transform.rotation);
        spl.GetComponent<ParticleSetup>().setColor(color);
        
        GameObject exp = Instantiate(explosion, transform.position, transform.rotation);
        exp.GetComponent<ParticleSetup>().setColor(color);

        GameObject popUp = Instantiate(killNumber, transform.position, Quaternion.identity);
        popUp.GetComponent<KillNumber>().Setup(health * comboMultiplier, color);

        FindObjectOfType<AudioManager>().Play("EnemyDeath");
    }
}
