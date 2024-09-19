using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    public float damage = 20f;  // Set the damage value for the bullet

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube"))  // Ensure your cubes are tagged as "Cube"
        {
            // Get the CubeHealth component on the collided cube
            CubeHealth cubeHealth = collision.gameObject.GetComponent<CubeHealth>();
            if (cubeHealth != null)
            {
                cubeHealth.TakeDamage(damage);  // Deal damage to the cube
            }
        }

        Destroy(gameObject);  // Destroy the bullet after impact
    }
}
