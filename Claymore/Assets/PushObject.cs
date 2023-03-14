using UnityEngine;

public class PushObject : MonoBehaviour
{
    public Vector3 forceDirection = Vector3.back; // Direction of the impulse force
    public float forceMagnitude = 100f; // Magnitude of the impulse force

    void OnEnable()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 force = forceDirection.normalized * forceMagnitude;
        rb.AddForce(force, ForceMode.Impulse);
    }
}
