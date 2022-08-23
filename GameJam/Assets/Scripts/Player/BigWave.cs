using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigWave : Upgrade
{
    void Start()
    {
        timer = 20f;
    }

    void Update()
    {
        if (!active) return;

        if (timer == 20f)
        {
            player.GetComponent<PlayerController>().WaveUp(2f);
        }

        timer -= Time.deltaTime;
        icon.fillAmount -= Time.deltaTime / 20f;

        if (timer < 0)
        {
            // scale down
            player.GetComponent<PlayerController>().WaveUp(0.5f);
            player.GetComponent<PlayerUpgrades>().Remove(this);
            Destroy(gameObject);
        }
    }
}
