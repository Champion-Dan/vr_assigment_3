using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class gameStart : MonoBehaviour
{

    public string bulletTag = "Bullet";  // Bullet tag for detection
    public string gameSceneName = "Scenes/MainScreen";  // Name of the game scene to load

   /* void Update()
    {
        float leftTriggerValue = triggerLeft.action.ReadValue<float>();
        float rightTriggerValue = triggerRight.action.ReadValue<float>();

        // Optionally still allow starting the game by pressing both triggers
        if (leftTriggerValue > 0.5f && rightTriggerValue > 0.5f)
        {
            StartGame();
        }
    }*/

    // This function detects collision with the "start" button
    private void OnCollisionEnter(Collision collision)
    {
        // Debugging log to check if collision is happening
        Debug.Log("Collision detected with: " + collision.gameObject.name);

        // Check if the object that collided is tagged as "Bullet"
        if (collision.gameObject.CompareTag(bulletTag))
        {
            Debug.Log("Bullet hit detected, starting the game!");
            StartGame();
        }
        else
        {
            Debug.Log("Collision with non-bullet object");
        }
    }

    // Function called to start the game
    private void StartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

}
