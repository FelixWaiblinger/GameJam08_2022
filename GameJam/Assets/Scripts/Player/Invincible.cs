using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincible : Upgrade
{
    private PlayerController script;

    void Start()
    {
        timer = 8f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!active) return;

        if (timer == 8f)
        {
            script = player.GetComponent<PlayerController>();
            script.SetInvincible();
        }

        timer -= Time.deltaTime;

        if (timer < 0)
        {
            script.SetInvincible();
            script.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
