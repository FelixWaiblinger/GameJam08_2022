using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincible : Upgrade
{
    private PlayerController playerScript;

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
            playerScript = player.GetComponent<PlayerController>();
            playerScript.SetInvincible();
        }

        timer -= Time.deltaTime;

        if (timer < 0)
        {
            playerScript.SetInvincible();
            playerScript.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
