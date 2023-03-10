using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Material material;

    public void ChangeColor()
    {
        material.SetColor("_EmissionColor", Color.black);
    }
}
