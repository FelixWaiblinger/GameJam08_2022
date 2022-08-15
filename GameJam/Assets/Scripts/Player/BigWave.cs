using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigWave : Upgrade
{
    private PlayerController playerScript;
        
    void Start()
    {
        timer = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!active) return;

        if (timer == 20f)
        {
            playerScript = player.GetComponent<PlayerController>();
            // scale up
            playerScript.WaveUp(2f);
        }

        timer -= Time.deltaTime;

        if (timer < 0)
        {
            // scale down
            playerScript.WaveUp(0.5f);
            playerScript.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
