using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    // These fields will appear in the Unity Inspector
    public GameObject Bullet;  // Reference to the bullet prefab
    public float shootPower = 100f;  // How fast the bullet will travel
    public InputActionReference Trigger;  // Input trigger for shooting
    public float bulletLifetime = 5f;  // Time in seconds before the bullet is destroyed

    // Start is called before the first frame update
    void Start()
    {
        // Check if the Trigger action is assigned in the Inspector
        if (Trigger == null)
        {
            Debug.LogError("Trigger is not assigned in the Inspector.");
            return;
        }

        // Check if the action is correctly assigned
        if (Trigger.action == null)
        {
            Debug.LogError("Trigger action is not assigned.");
            return;
        }

        // Subscribe to the trigger action event
        Debug.Log("Trigger action is assigned. Subscribing to event.");
        Trigger.action.performed += Shoot;  // Attach the Shoot method to the trigger action
    }

    // Method called when the trigger is pressed
    void Shoot(InputAction.CallbackContext __)
    {
        // Check if Bullet prefab is assigned in the Inspector
        if (Bullet == null)
        {
            Debug.LogError("Bullet is not assigned.");
            return;
        }

        // Create a new bullet instance at the player's position and rotation
        GameObject newBullet = Instantiate(Bullet, transform.position, transform.rotation);
        Rigidbody rb = newBullet.GetComponent<Rigidbody>();

        // Apply velocity to the bullet if it has a Rigidbody
        if (rb != null)
        {
            rb.velocity = transform.forward * shootPower;  // Bullet moves forward based on shootPower
        }

        // Start the coroutine to destroy the bullet after a delay
        StartCoroutine(DestroyBulletAfterDelay(newBullet, bulletLifetime));
    }

    // Coroutine to destroy the bullet after a set time
    private IEnumerator DestroyBulletAfterDelay(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }
}
