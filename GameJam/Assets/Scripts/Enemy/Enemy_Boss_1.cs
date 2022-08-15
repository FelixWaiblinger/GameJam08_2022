using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Boss_1 : Enemy {
    [SerializeField] private float delayTime = 6f;

    private float delay;

    void Start() {
        FindPlayer();
        FindEnemyTypes();
        FindComboEvent();
        health = 20;
        color = new Color(253, 19, 61);
        delay = delayTime;
    }

    void Update() {
        if (activateTimer < 0)
            col.enabled = true;
        else
            activateTimer -= Time.deltaTime;
            
        if (delay > 0) delay -= Time.deltaTime;
        else {
            transform.localScale += (new Vector3(0.5f, 0.5f, 1f));
            delay = delayTime;
        }

        MoveToPlayer();
    }
}
