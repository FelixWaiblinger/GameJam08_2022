using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : Upgrade
{
    void Start()
    {
        timer = 6f;
    }

    void Update()
    {
        if (!active) return;

        if (timer == 6f)
        {
            player.GetComponent<PlayerController>().SpeedUp(2f);
        }

        timer -= Time.deltaTime;
        icon.fillAmount -= Time.deltaTime / 6f;

        if (timer < 0)
        {
            player.GetComponent<PlayerController>().SpeedUp(0.5f);
            player.GetComponent<PlayerUpgrades>().Remove(this);
            Destroy(gameObject);
        }
    }
}
