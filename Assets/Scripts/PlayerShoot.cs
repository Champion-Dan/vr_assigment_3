using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    public GameObject BulletTemplate;
    public float shootPower = 100f;
    public InputActionReference trigger;
    public float bulletLifetime = 5f;  // Time in seconds before the bullet is destroyed

    // Start is called before the first frame update
    void Start()
    {
        if (trigger == null)
        {
            Debug.LogError("Trigger is not assigned in the Inspector.");
            return;
        }

        if (trigger.action == null)
        {
            Debug.LogError("Trigger action is not assigned.");
            return;
        }

        Debug.Log("Trigger action is assigned. Subscribing to event.");
        trigger.action.performed += Shoot;  // Attach the Shoot method to the trigger action
    }

    void Shoot(InputAction.CallbackContext __)
    {
        if (BulletTemplate == null)
        {
            Debug.LogError("BulletTemplate is not assigned.");
            return;
        }

        GameObject newBullet = Instantiate(BulletTemplate, transform.position, transform.rotation);
        Rigidbody rb = newBullet.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.velocity = transform.forward * shootPower;  // Adjust velocity for faster bullets
        }

        // Start the coroutine to destroy the bullet after a delay
        StartCoroutine(DestroyBulletAfterDelay(newBullet, bulletLifetime));
    }

    private IEnumerator DestroyBulletAfterDelay(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }
}
