using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public Transform destination;
    [SerializeField] float radius = 5f;

    private void PlayerTeleport(Collider2D other)
    {
        other.transform.position = destination.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerTeleport(other);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(destination.position, radius);
    }
}
