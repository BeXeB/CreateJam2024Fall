using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyPrefabs;
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private float spawnInterval = 1f;
    
    private void Start()
    {
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
        //TODO change the spawn interval based on the timer
    }
}
