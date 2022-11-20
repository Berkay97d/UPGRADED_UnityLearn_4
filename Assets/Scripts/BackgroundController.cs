using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private Vector3 startPosition;
    private float repeatPoint;

    private void Start()
    {
        startPosition = transform.position;
        repeatPoint = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        ResetBackground();
    }

    void ResetBackground()
    {
        if (transform.position.x < startPosition.x - repeatPoint)
        {
            transform.position = startPosition;
        }
    }
}
