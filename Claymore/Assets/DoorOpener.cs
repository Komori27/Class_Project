using UnityEngine;

public class DoorOpener : MonoBehaviour
{
   // public Animator animator;
    public Animator targetAnimator;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.transform.parent == transform.parent)
            {
                Debug.Log("Open");
                targetAnimator.SetTrigger("Open");
            }
        }
        else
        {
            targetAnimator.SetBool("Idle", false);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.transform.parent == transform.parent)
            {
                Debug.Log("Close");
                targetAnimator.SetTrigger("Close");
            }
        }
        else 
        {
            targetAnimator.SetBool("Idle", true);
        }
    }
}
