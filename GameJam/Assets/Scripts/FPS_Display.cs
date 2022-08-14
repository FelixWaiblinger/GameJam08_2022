using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FPS_Display : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI FPSText;
    [SerializeField] private float pollingTime = 1f;
    [SerializeField] private float time;
    [SerializeField] private int frameCount;


    void Update() {
        time += Time.deltaTime;

        frameCount++;
        if (time >= pollingTime) {
            int frameRate = Mathf.RoundToInt(frameCount / time);
            FPSText.text = frameRate.ToString() + " FPS";
            //reset
            time -= pollingTime;
            frameCount = 0;
        }
    }
}
