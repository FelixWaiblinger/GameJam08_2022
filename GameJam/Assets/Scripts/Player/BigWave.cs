using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigWave : Upgrade
{
    private PlayerController playerScript;
    private WaveController waveScript;
    
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
            waveScript = wave.GetComponent<WaveController>();
            playerScript = player.GetComponent<PlayerController>();
            // scale up
            waveScript.DamageUp(2f);
            waveScript.ScalingUp(2f);
        }

        timer -= Time.deltaTime;

        if (timer < 0)
        {
            // scale down
            waveScript.DamageUp(0.5f);
            waveScript.ScalingUp(0.5f);
            playerScript.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
