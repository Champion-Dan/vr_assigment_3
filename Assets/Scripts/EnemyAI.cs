using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player; // Reference to the player
    public float followRange = 10f; // Distance within which the enemy starts to follow
    public float speed = 2f; // Speed at which the enemy moves

    private Rigidbody rb; // Reference to the Rigidbody component

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component
    }

    private void Update()
    {
        // Check the distance between the enemy and the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // If the player is within follow range, move towards the player
        if (distanceToPlayer <= followRange)
        {
            Vector3 direction = (player.position - transform.position).normalized;

            // Move the enemy using Rigidbody.MovePosition
            rb.MovePosition(transform.position + direction * speed * Time.deltaTime);

            // Optionally, make the enemy look at the player
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the enemy collides with the player
        if (other.transform == player)
        {
            // End the game (you can replace this with your own logic)
            Debug.Log("Game Over!");
            // Example to quit the game or stop play mode in the editor
            Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}
