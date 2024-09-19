using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    // Store the start position of the target
    private Vector3 startPosition;

    // Speed of movement
    public float moveSpeed = 2f; // You can adjust this value for faster/slower movement
    public float moveRange = 2f; // The range the target moves in the x direction

    void Start()
    {
        // Store the initial position of the target
        startPosition = transform.position;
    }

    void Update()
    {
        // Move the target back and forth using Mathf.Sin and Time.time
        // This will move the target left and right between the moveRange
        transform.position = startPosition + new Vector3(Mathf.Sin(Time.time * moveSpeed) * moveRange, 0f, 0f);
    }

}
