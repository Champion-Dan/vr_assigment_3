using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Audio;

public class PlayerShoot : MonoBehaviour
{
    public GameObject Bullet;  // Reference to the bullet prefab
    public float shootPower = 100f;  // How fast the bullet will travel
    public InputActionReference Trigger;  // Input trigger for shooting
    public float bulletLifetime = 5f;  // Time in seconds before the bullet is destroyed
    public AudioClip shootSoundClip;  // Assign any sound clip in the Inspector

    private AudioSource audioSource;  // Reference to AudioSource component

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
        Trigger.action.performed += Shoot;

        // Get or add the AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // Add an AudioSource component if it's missing
            audioSource = gameObject.AddComponent<AudioSource>();
            Debug.Log("AudioSource was missing, so one was added.");
        }


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

        // Create the bullet at the current position and rotation of the object with this script
        GameObject newBullet = Instantiate(Bullet, transform.position, transform.rotation);
        Rigidbody rb = newBullet.GetComponent<Rigidbody>();

        // Apply velocity to the bullet based on the object's forward direction
        if (rb != null)
        {
            rb.velocity = transform.forward * shootPower; // Shoot in the forward direction of the object
        }

        // Play the shooting sound if AudioClip is assigned
        if (shootSoundClip != null && audioSource != null)
        {
            audioSource.PlayOneShot(shootSoundClip);  // Play the assigned audio clip once
        }
        else
        {
            Debug.LogWarning("No AudioClip assigned or AudioSource missing for the shoot sound.");
        }

        // Destroy bullet after a set time
        StartCoroutine(DestroyBulletAfterDelay(newBullet, bulletLifetime));
    }

    // Coroutine to destroy the bullet after a set time
    private IEnumerator DestroyBulletAfterDelay(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }
}
