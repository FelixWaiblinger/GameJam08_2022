using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : Upgrade
{
    private PlayerController playerScript;

    void Start()
    {
        timer = 6f;
    }

    void Update()
    {
        if (!active) return;

        if (timer == 6f)
        {
            playerScript = player.GetComponent<PlayerController>();
            playerScript.SpeedUp(2f);
        }

        timer -= Time.deltaTime;

        if (timer < 0)
        {
            playerScript.SpeedUp(0.5f);
            playerScript.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
