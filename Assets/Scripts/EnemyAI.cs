using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // Speed for enemy movement
    [SerializeField]
    private float move_speed = 10f;

    // Time interval between shots
    [SerializeField]
    private float shootingInterval = 2f;

    // Bullet prefab to shoot
    [SerializeField]
    private GameObject bulletPrefab;

    // Speed of the bullet
    [SerializeField]
    private float bulletSpeed = 20f;

    // Reference to player object
    private GameObject playerTarget;

    // Time tracking for shooting
    private float timeSinceLastShot = 0f;

    // Update is called once per frame
    void Update()
    {
        if (playerTarget != null)
        {
            // Look at the player
            transform.LookAt(playerTarget.transform.position);

            // Move towards the player
            transform.position += transform.forward * move_speed * Time.deltaTime;

            // Shoot periodically
            timeSinceLastShot += Time.deltaTime;
            if (timeSinceLastShot >= shootingInterval)
            {
                Shoot();
                timeSinceLastShot = 0f;
            }
        }
    }

    // Shoot a bullet in the direction the enemy is facing
    private void Shoot()
    {
        // Instantiate the bullet prefab at the enemy's position and rotation
        GameObject bullet = Instantiate(bulletPrefab, transform.position + transform.forward, transform.rotation);

        // Get the Rigidbody component of the bullet and apply forward force
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * bulletSpeed;

        // Destroy the bullet after 5 seconds to avoid memory leaks
        Destroy(bullet, 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Set the player as the target when the enemy enters a trigger
        playerTarget = other.gameObject;
    }
}
