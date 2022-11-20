using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    private Vector3 spawnPosition;
    private PlayerController playerController;
    
    
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        
        InvokeRepeating("SpawnObstacles",2,2);
    }

    
    void SpawnObstacles()
    {
        if (!playerController.isGameOver)
        {
            int randomX = Random.Range(18, 28);
            spawnPosition = new Vector3(randomX, 0, 0); 
            Instantiate(prefab, spawnPosition, prefab.transform.rotation);
        }
    }
}
