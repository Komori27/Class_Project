using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class FootstepController : MonoBehaviour
{
    public AudioSource footstepAudioSource;
    public AudioClip[] footstepSounds;
    public float footstepDelay = 0.5f;

    private bool isGrounded = true;

    [SerializeField] PlatformerPlayer platformerPlayer;
    [SerializeField] private Rigidbody2D rb;

    private float lastFootstepTime;


    private void Update()
    {
        if (isGrounded || !platformerPlayer.isDodging)
        {
            // Check if the player is moving
            if (rb.velocity.magnitude > 0)
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
    public void SetGrounded(bool grounded)
    {
        isGrounded = grounded;
    }
}
