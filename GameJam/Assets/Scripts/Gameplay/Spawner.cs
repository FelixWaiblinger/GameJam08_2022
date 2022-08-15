using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyTypes;
    [SerializeField] private GameObject[] upgradesTypes;
    [SerializeField] private float enemySpawnTime = 2f;
    [SerializeField] private float upgradeSpawnTime = 10f;
    [SerializeField] private float gizmoX = 10f;
    [SerializeField] private float gizmoY = 10f;
    private float enemyTimer;
    private float upgradeTimer;

    public GameObject[] getEnemyTypes() { return enemyTypes; }

    void Start()
    {
        enemyTimer = enemySpawnTime;
        upgradeTimer = upgradeSpawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        enemyTimer -= Time.deltaTime;
        upgradeTimer -= Time.deltaTime;

        float x = 0, y = 0;
        int idx = 0;
        
        if (enemyTimer < 0)
        {
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
            
            if (Time.timeSinceLevelLoad < 30)
                idx = Random.Range(0, Mathf.Min(2, enemyTypes.Length));

            else if (Time.timeSinceLevelLoad < 60)
                idx = Random.Range(0, Mathf.Min(4, enemyTypes.Length));

            else
                idx = Random.Range(Mathf.Min(2, enemyTypes.Length - 1), Mathf.Min(5, enemyTypes.Length));

            Instantiate(enemyTypes[idx], new Vector3(x, y, 0), Quaternion.identity);

            enemyTimer = enemySpawnTime;
        }

        if (upgradeTimer < 0)
        {
            x = Random.Range(-9.0f, 9.0f);
            y = Random.Range(-5.0f, 5.0f);
            idx = Random.Range(0, upgradesTypes.Length);

            Instantiate(upgradesTypes[idx], new Vector3(x, y, 0f), Quaternion.identity);

            upgradeTimer = upgradeSpawnTime;
        }

        // increasing difficulty
        float time = Time.timeSinceLevelLoad;
        if (time > 30) enemySpawnTime = 1.5f;
        if (time > 60) enemySpawnTime = 1f;
        if (time > 90) enemySpawnTime = 0.5f;
        if (time > 120) enemySpawnTime = 0.25f;
        if (time > 150) enemySpawnTime = 0.125f;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(Vector3.zero, new Vector3(gizmoX, gizmoY, 0));
    }
}
