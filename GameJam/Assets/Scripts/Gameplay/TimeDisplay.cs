using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimeDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeDisplay;
    private int min = 0;
    private float sec = 0f;
    private bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        PlayerController.gameOverEvent += setGameOver;
        timeDisplay.text = string.Format("Time:\t{0:00}:{1:00}:{2:00}", min, sec, (int)(sec * 100) % 100);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver) return;

        sec = Time.timeSinceLevelLoad;

        timeDisplay.text = string.Format("Time:\t{0:00}:{1:00}:{2:00}",
                            Mathf.Floor(sec / 60),
                            Mathf.FloorToInt(sec % 60),
                            Mathf.FloorToInt(sec * 100) % 100);
    }

    private void setGameOver()
    {
        gameOver = true;
    }
}
