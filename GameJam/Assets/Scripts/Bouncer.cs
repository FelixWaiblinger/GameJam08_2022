using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    private Vector3 scale = new Vector3(0.005f, -0.005f, 0f);
    private int sign = 1;
    private float timer = 0.3f;

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            timer = 0.3f;
            sign *= -1;
        }

        for (int i = 0; i < enemies.Length; ++i)
        {
            enemies[i].transform.localScale += scale * sign;
        }
    }
}
