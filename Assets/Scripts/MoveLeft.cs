using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    [SerializeField] private float speed;
    private PlayerController playerController;

    
    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }


    void Update()
    {
        if (!playerController.isGameOver)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);    
        }
    }
}
