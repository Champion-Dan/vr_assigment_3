using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*public class RayCastTeleport : MonoBehaviour
{
    [SerializeField]
    private GameObject playerOrigin;
    [SerializeField]
    private LayerMask teleportMask;
    [SerializeField]
    private InputActionReference teleportButtonPress;

    void Start()
    {
        if (teleportButtonPress != null && teleportButtonPress.action != null)
        {
            teleportButtonPress.action.performed += DoRaycast;
        }
        else
        {
            Debug.LogError("TeleportButtonPress or its action is not assigned.");
        }

        if (playerOrigin == null)
        {
            Debug.LogError("PlayerOrigin is not assigned.");
        }
    }

    void DoRaycast(InputAction.CallbackContext __)
    {
        RaycastHit hit;
        bool didHit = Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, teleportMask);
        if (didHit)
        {
            Debug.Log(hit.collider.gameObject.name);
            playerOrigin.transform.position = hit.point; // Teleport to hit point
        }
    }

    void OnDestroy()
    {
        if (teleportButtonPress != null && teleportButtonPress.action != null)
        {
            teleportButtonPress.action.performed -= DoRaycast;
        }
    }
}*/
