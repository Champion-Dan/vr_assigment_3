using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemyAI : MonoBehaviour
{
    // Time interval between shots
    [SerializeField]
    private float shootingInterval = 2f;

    // Bullet prefab to shoot
    [SerializeField]
    private GameObject bulletPrefab;

    // Speed of the bullet
    [SerializeField]
    private float bulletSpeed = 20f;

    // Damage dealt by the bullet
    [SerializeField]
    private int bulletDamage = 10; // Set the damage for the bullet

    // Reference to player object
    private GameObject playerTarget;

    // Time tracking for shooting
    private float timeSinceLastShot = 0f;

    // Detection range for the enemy
    [SerializeField]
    private float detectionRange = 15f;

    void Start()
    {
        // Assuming the player has a tag "Player"
        playerTarget = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTarget != null)
        {
            // Calculate the distance to the player
            float distanceToPlayer = Vector3.Distance(transform.position, playerTarget.transform.position);

            // Check if the player is within detection range
            if (distanceToPlayer <= detectionRange)
            {
                // Enemy looks at the player
                transform.LookAt(playerTarget.transform.position);

                // Shoot periodically
                timeSinceLastShot += Time.deltaTime;
                if (timeSinceLastShot >= shootingInterval)
                {
                    Shoot();
                    timeSinceLastShot = 0f;
                }
            }
        }
    }

    // Shoot a bullet towards the player's current position
    private void Shoot()
    {
        // Instantiate the bullet prefab at the enemy's position
        GameObject bullet = Instantiate(bulletPrefab, transform.position + transform.forward, Quaternion.identity);

        // Calculate direction towards the player
        Vector3 directionToPlayer = (playerTarget.transform.position - transform.position).normalized;

        // Get the Rigidbody component of the bullet and apply force in the direction of the player
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = directionToPlayer * bulletSpeed;
        }

        // Set the bullet's damage
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.damage = bulletDamage; // Assign the damage to the bullet
        }

        // Destroy the bullet after 5 seconds to avoid memory leaks
        Destroy(bullet, 5f);
    }

}
