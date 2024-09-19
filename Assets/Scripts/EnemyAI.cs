using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float move_speed = 10f;
    private GameObject playerTarget;

    // Update is called once per frame
    void Update()
    {
        if (playerTarget != null)
        {
            transform.LookAt(playerTarget.transform.position);
            transform.position += transform.forward * move_speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        playerTarget = other.gameObject;
    }
}