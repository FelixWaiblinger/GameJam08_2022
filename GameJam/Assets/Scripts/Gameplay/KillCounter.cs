using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI overall;
    [SerializeField] private TextMeshProUGUI combo;
    [SerializeField] private float comboTime = 6f;
    private int kills = 0;
    private int killsWithinTime = 0;
    private float timer;

    public static event Action<int> comboEvent;

    void Start()
    {
        Enemy.killEvent += AddKill;
        timer = comboTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < comboTime) timer += Time.deltaTime;

        overall.text = "Kills:\t" + kills.ToString();
        combo.text = "Combo:\t" + killsWithinTime.ToString();
    }

    void AddKill(int worth)
    {
        // combo multiplier
        if (killsWithinTime > 80)
        {
            worth *= 4;
            comboEvent(4);
        }
        else if (killsWithinTime > 40)
        {
            worth *= 3;
            comboEvent(3);
        }
        else if (killsWithinTime > 20)
        {
            worth *= 2;
            comboEvent(2);
        }

        kills += worth;

        if (timer >= comboTime)
        {
            killsWithinTime = 0;
            combo.text = killsWithinTime.ToString();
        }

        timer = 0f;
        killsWithinTime += 1;
    }
}
