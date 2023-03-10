using UnityEngine;

public class ChildScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        // Get the SpriteRenderer component
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Subscribe to the OnParentDied event
        //ParentScript.OnParentDied += OnParentDiedHandler;
    }

    private void OnParentDiedHandler()
    {
        // Disable the SpriteRenderer
        spriteRenderer.enabled = false;
    }

    private void OnDestroy()
    {
        // Unsubscribe from the OnParentDied event when the object is destroyed
        //ParentScript.OnParentDied -= OnParentDiedHandler;
    }
}
