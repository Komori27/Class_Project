using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class GhoulFootstepController : MonoBehaviour
{
    public AudioSource footstepAudioSource;
    public AudioClip[] footstepSounds;
    public float footstepDelay = 0.5f;

    [SerializeField] private Rigidbody2D rb;
    private float lastFootstepTime;
    [SerializeField] Enemy enemyScript;

    private void Start()
    {
        enemyScript = GetComponent<Enemy>();
    }

    private void Update()
    {
        if (rb.gameObject.activeSelf && !enemyScript.isDead)
        {
            // Check if enough time has passed since the last footstep
            if (Time.time - lastFootstepTime > footstepDelay)
            {
                // Play a random footstep sound
                footstepAudioSource.clip = footstepSounds[Random.Range(0, footstepSounds.Length)];
                footstepAudioSource.Play();

                // Update the last footstep time
                lastFootstepTime = Time.time;
            }
        }
    }
}
