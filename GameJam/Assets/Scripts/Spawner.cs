using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyTypes;
    [SerializeField] private float spawnTime = 2;
    [SerializeField] private float gizmoX = 10;
    [SerializeField] private float gizmoY = 10;
    private float timer;

    void Start()
    {
        timer = spawnTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            return;
        }

        float x = 0, y = 0;

        // spawn along upper / lower area
        if (Random.value >= 0.5)
        {
            x = Random.Range(-10.0f, 10.0f);
            float r = Random.value;
            y = Random.value >= 0.5 ? -6.0f + r : 6.0f - r;
        }
        // spawn along left / right area
        else
        {
            y = Random.Range(-6.0f, 6.0f);
            float r = Random.value;
            x = Random.value >= 0.5 ? -10.0f + r : 10.0f - r;
        }

        int idx = Random.Range(0, enemyTypes.Length);

        Instantiate(enemyTypes[idx], new Vector3(x, y, 0), Quaternion.identity);

        timer = spawnTime;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(Vector3.zero, new Vector3(gizmoX, gizmoY, 0));
        
    }
}
