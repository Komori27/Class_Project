using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRefill : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth player = other.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.Healing();
            Debug.Log("Healing");
        }
    }
}
