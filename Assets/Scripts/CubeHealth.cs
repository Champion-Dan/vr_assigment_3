using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeHealth : MonoBehaviour
{
    public float health = 100f;  // Set the initial health

    // Method to take damage
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);  // Destroy the cube when health reaches zero
        }
    }
}

