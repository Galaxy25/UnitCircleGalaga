using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private float spawnRate = 6.0f;  

    private bool canSpawn = true;
    private Vector3[] unitCirclePoints = 
    {
        new Vector3(1.0f, 0, 0),
        new Vector3(Mathf.Sqrt(3.0f) / 2.0f, 0.5f, 0),
        new Vector3(Mathf.Sqrt(2.0f) / 2.0f, Mathf.Sqrt(2.0f) / 2.0f, 0),
        new Vector3(0.5f, Mathf.Sqrt(3.0f) / 2.0f, 0),
        new Vector3(0, 1.0f, 0),
        new Vector3(-0.5f, Mathf.Sqrt(3.0f) / 2.0f, 0),
        new Vector3(-Mathf.Sqrt(2.0f) / 2.0f, Mathf.Sqrt(2.0f) / 2.0f, 0),
        new Vector3(-Mathf.Sqrt(3.0f) / 2.0f, 0.5f, 0),
        new Vector3(-1.0f, 0, 0),
        new Vector3(-Mathf.Sqrt(3.0f) / 2.0f, -0.5f, 0),
        new Vector3(-Mathf.Sqrt(2.0f) / 2.0f, -Mathf.Sqrt(2.0f) / 2.0f, 0),
        new Vector3(-0.5f, -Mathf.Sqrt(3.0f) / 2.0f, 0),
        new Vector3(0, -1.0f, 0),
        new Vector3(0.5f, -Mathf.Sqrt(3.0f) / 2.0f, 0),
        new Vector3(Mathf.Sqrt(2.0f) / 2.0f, -Mathf.Sqrt(2.0f) / 2.0f, 0),
        new Vector3(Mathf.Sqrt(3.0f) / 2.0f, -0.5f, 0)
    };

    private void Update()
    {
        if (canSpawn)
        {
            StartCoroutine(SpawnEnemy());
        }

        BasicEnemy.speedIncreaser = 1.0f + Time.timeSinceLevelLoad / 60.0f;
        spawnRate = 6.0f / (1.0f + Time.timeSinceLevelLoad / 80.0f);
    }

    private IEnumerator SpawnEnemy()
    {
        canSpawn = false;
        Vector3 spawnPosition = unitCirclePoints[Random.Range(0, unitCirclePoints.Length)] * 4.0f;
        Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], spawnPosition, Quaternion.identity);
        yield return new WaitForSeconds(spawnRate);
        canSpawn = true;
    }
}
