using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KillCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI overall;
    [SerializeField] private TextMeshProUGUI combo;
    [SerializeField] private Image splatter;
    [SerializeField] private Slider comboBar;
    [SerializeField] private float comboTime = 6f;
    private int kills = 0;
    private int killsWithinTime = 0;
    private float timer;

    public static event Action<int> comboEvent;

    void OnDestroy()
    {
        Enemy.killEvent -= AddKill;
    }

    void Start()
    {
        Enemy.killEvent += AddKill;
        timer = comboTime;
        splatter.color = new Color(0, 0, 0, 0);
        comboBar.minValue = 0f;
        comboBar.maxValue = comboTime;
        comboBar.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            comboBar.value -= Time.deltaTime;
        }
        else
        {
            comboBar.gameObject.SetActive(false);
            killsWithinTime = 0;
        }

        overall.text = "Kills:\t" + kills.ToString();
        combo.text = "Combo:\t" + killsWithinTime.ToString();
    }

    void AddKill(int worth)
    {
        killsWithinTime += 1;

        comboBar.gameObject.SetActive(true);
        comboBar.value = comboTime;
        timer = comboTime;

        // combo multiplier
        if (killsWithinTime >= 80)
        {
            worth *= 4;
            comboEvent(4);
            splatter.color = new Color(152, 0, 0, 255);
        }
        else if (killsWithinTime >= 40)
        {
            worth *= 3;
            comboEvent(3);
            splatter.color = new Color(174, 63, 0, 255);
        }
        else if (killsWithinTime >= 20)
        {
            worth *= 2;
            comboEvent(2);
            splatter.color = new Color(190, 106, 0, 255);
        }
        // reset
        else
        {
            comboEvent(1);
            splatter.color = new Color(0, 0, 0, 0);
        }

        kills += worth;
    }
}
