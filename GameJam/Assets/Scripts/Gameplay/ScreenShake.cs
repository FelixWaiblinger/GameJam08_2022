using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    [SerializeField] private float shakeStrength = 0.007f;
    [SerializeField] private float shakeLength = 0.02f;

    private Camera main;

    void OnDestroy() {
        Enemy.killEvent -= Shake;
    }

    void Start()
    {
        Enemy.killEvent += Shake;
        main = gameObject.GetComponent<Camera>();
    }

    void Shake(int amount)
    {
        StartCoroutine(_Shake(amount));
    }

    IEnumerator _Shake(int amount)
    {
        float range = shakeStrength * amount;

        for (int i = 0; i < 10; ++i)
        {
            main.orthographicSize += Random.Range(-range, range);
            yield return new WaitForSeconds(shakeLength);
        }

        // reset to normal
        main.orthographicSize = 5f;
    }
}
