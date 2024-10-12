using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public InputActionReference Move; // Reference for movement input (analog stick)
    public float moveSpeed = 5f; // Speed of the player movement
    public InputActionReference Jump; // Optional: Reference for jump input
    public float jumpForce = 5f; // Jump force for the player (if jumping is implemented)

    private Rigidbody rb; // Reference to the player's Rigidbody component
    private Vector2 moveInput; // Store the movement input

    // Start is called before the first frame update
    void Start()
    {
        // Check if Move action is assigned
        if (Move == null || Move.action == null)
        {
            Debug.LogError("Move action is not assigned in the Inspector.");
            return;
        }

        // Subscribe to the movement action
        Move.action.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        Move.action.canceled += ctx => moveInput = Vector2.zero;

        // Optional: Subscribe to the jump action
        if (Jump != null && Jump.action != null)
        {
            Jump.action.performed += ctx => JumpPlayer();
        }

        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component is missing on the player.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Handle player movement in Update
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (rb != null)
        {
            // Convert the input into movement
            Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y);
            moveDirection = transform.TransformDirection(moveDirection); // Adjust based on player's current direction
            rb.velocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y, moveDirection.z * moveSpeed);
        }
    }

    private void JumpPlayer()
    {
        if (rb != null && Mathf.Abs(rb.velocity.y) < 0.01f) // Check if the player is grounded
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Apply a jump force
        }
    }
}
