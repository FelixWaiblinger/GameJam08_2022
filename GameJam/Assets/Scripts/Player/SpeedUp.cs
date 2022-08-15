using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : Upgrade
{
    private PlayerController script;

    void Start()
    {
        timer = 15f;
    }

    void Update()
    {
        if (!active) return;

        if (timer == 15f)
        {
            script = player.GetComponent<PlayerController>();
            script.SpeedUp(2f);
        }

        timer -= Time.deltaTime;

        if (timer < 0)
        {
            script.SpeedUp(0.5f);
            script.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
