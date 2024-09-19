using UnityEngine;

public class TimeScaleController : MonoBehaviour
{
    // Public reference to the hand controller object
    public GameObject rightHandReference;

    // Variable to store the position of the controller from the last frame
    private Vector3 previousRightHandPosition = Vector3.zero;

    // Variables for time scale adjustment
    public float movementThreshold = 0.1f; // Set a threshold for hand movement
    public float minTimeScale = 0.1f; // Minimum time scale value (slowest)
    public float maxTimeScale = 1.0f; // Maximum time scale value (normal speed)

    void Update()
    {
        if (rightHandReference != null)
        {
            // Calculate the distance the hand has moved between frames
            float distance = Vector3.Distance(previousRightHandPosition, rightHandReference.transform.position);

            // Adjust time scale based on hand movement
            if (distance > movementThreshold)
            {
                // The more the hand moves, the closer to maxTimeScale
                Time.timeScale = Mathf.Lerp(minTimeScale, maxTimeScale, distance / movementThreshold);
            }
            else
            {
                // Keep time scale at minimum when there's little movement
                Time.timeScale = minTimeScale;
            }

            // Update the previous hand position
            previousRightHandPosition = rightHandReference.transform.position;
        }
    }
}
