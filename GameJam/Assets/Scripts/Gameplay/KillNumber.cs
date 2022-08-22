using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillNumber : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI number;
    [SerializeField] private Vector3 move = new Vector3(0, 0.007f, 0);
    [SerializeField] private float timer = 1f;

    public void Setup(int num)
    {
        number.overrideColorTags = true;
        number.SetText("+" + num.ToString());
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0.6f)
            number.transform.position += move;

        if (timer < 0.1f)
            number.alpha -= 40;

        if (timer < 0)
            Destroy(gameObject);
    }
}
