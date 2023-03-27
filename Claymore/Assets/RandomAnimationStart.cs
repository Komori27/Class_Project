using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnimationStart : MonoBehaviour
{
    public float maxTimeOffset = 1f;
    void Start()
    {
        // Get a reference to the Animator component
        Animator animator = GetComponent<Animator>();

        // Get the current state of the animator
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // Set the time of the current state to a random value
        float randomTimeOffset = Random.Range(0f, maxTimeOffset);
        animator.Play(stateInfo.fullPathHash, -1, randomTimeOffset);
    }
}
