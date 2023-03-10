using UnityEngine;
using System.Collections;

public class ChangeLight : MonoBehaviour
{
    public Color newColor;
    public Light light;
    public float duration = 3.0f; // The duration over which the color will change


    private Color originalColor;

    void Start()
    {
        originalColor = light.color; // Store the original color of the light
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("ChangeLight");
            StartCoroutine(ChangeLightColorOverTime(newColor, duration));
        }
    }
    /*
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            light.color = originalColor; // Change the color of the light back to its original color
        }
    }
    */

    IEnumerator ChangeLightColorOverTime(Color newColor, float duration)
    {
        Color currentColor = light.color;
        float elapsedTime = 0.0f;
        while (elapsedTime < duration)
        {
            light.color = Color.Lerp(currentColor, newColor, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        light.color = newColor;
    }

}
