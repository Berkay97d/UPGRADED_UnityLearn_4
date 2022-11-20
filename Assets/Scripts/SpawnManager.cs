using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    public GameObject[] obstaclePrefabs;
    public float spawnRatePerSecond;


    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private void Update()
    {
       
    }


    private IEnumerator SpawnRoutine()
    {
        var waitTime = 1f / spawnRatePerSecond;
        
        while (!UIManager.isGameOver)
        {
            yield return new WaitForSeconds(waitTime);
            
            SpawnRandomObstacle();
        }
    }


    private void SpawnRandomObstacle()
    {
        var randomObstacleIndex = Random.Range(0, obstaclePrefabs.Length);
        var randomObstaclePrefab = obstaclePrefabs[randomObstacleIndex];
        Instantiate(randomObstaclePrefab, transform.position, Quaternion.identity, transform);
    }
}
