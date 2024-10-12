using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Set the damage the bullet does
    public int damage = 10; // Set this to your desired damage value

    private void OnCollisionEnter(Collision collision)
    {
        // Log the name of the object we collided with for debugging
        Debug.Log($"Collision with: {collision.gameObject.name}");

        // If the object hit is the player, apply damage (optional, based on your game's requirements)
        if (collision.gameObject.CompareTag("Player"))
        {
            // Get the GameOver component from the player
            GameOver gameOverScript = collision.gameObject.GetComponent<GameOver>();
            if (gameOverScript != null)
            {
                gameOverScript.TakeDamage(damage); // Call TakeDamage on GameOver script
                Debug.Log($"Damage dealt: {damage}");
            }
        }

        Destroy(gameObject); // Destroy the bullet regardless of what it hits
    }
}
