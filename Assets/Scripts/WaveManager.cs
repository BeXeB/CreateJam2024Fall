using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyPrefabs;
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private float startSpawnInterval = 10f;
    [SerializeField] private float endSpawnInterval = 0.5f;
    private float spawnInterval;
    private Timer timer;

    private void Awake()
    {
        timer = FindObjectOfType<Timer>();
    }

    private void Start()
    {
        spawnInterval = startSpawnInterval;
        StartCoroutine(SpawnEnemies());
    }
    
    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            var randomIndex = UnityEngine.Random.Range(0, enemyPrefabs.Count);
            var randomSpawnPoint = UnityEngine.Random.Range(0, spawnPoints.Count);
            Instantiate(enemyPrefabs[randomIndex], spawnPoints[randomSpawnPoint].position, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    
    private void Update()
    {
        if (timer.TimeLeft <= 0)
        {
            StopCoroutine(SpawnEnemies());
        }
        var remainingTimeFraction = timer.TimeLeft / timer.StartTime;
        spawnInterval = Mathf.Lerp(endSpawnInterval, startSpawnInterval, remainingTimeFraction);
    }
}
