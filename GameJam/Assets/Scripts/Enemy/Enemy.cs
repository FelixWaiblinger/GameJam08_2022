using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected Transform player;
    [SerializeField] protected Spawner spawner;
    [SerializeField] protected GameObject splash;
    [SerializeField] protected GameObject explosion;
    [SerializeField] protected GameObject killNumber;
    [SerializeField] protected Collider2D col;
    [SerializeField] protected float movementSpeed = 1f;
    
    protected int comboMultiplier = 1;
    protected Color color;
    protected int startHealth;
    protected int currentHealth;
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

    public abstract void TakeDamage(int dmg);

    protected void Die()
    {
        killEvent(startHealth);
        Destroy(gameObject);
        
        GameObject spl = Instantiate(splash, transform.position, transform.rotation);
        spl.GetComponent<ParticleSetup>().setColor(color);
        
        GameObject exp = Instantiate(explosion, transform.position, transform.rotation);
        exp.GetComponent<ParticleSetup>().setColor(color);

        GameObject popUp = Instantiate(killNumber, transform.position, Quaternion.identity);
        popUp.GetComponent<KillNumber>().Setup(startHealth * comboMultiplier);

        FindObjectOfType<AudioManager>().Play("EnemyDeath");
    }
}
