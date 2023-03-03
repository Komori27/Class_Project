using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGrounded;
    public LayerMask groundLayer;
    public float sphereRadius;
    public float sphereOffset;
    public float sphereCastDistance;

    void Update()
    {
        CheckGrounded();
    }

    void CheckGrounded()
    {
        Vector3 spherePos = transform.position + Vector3.up * sphereOffset;
        Collider[] colliders = Physics.OverlapSphere(spherePos, sphereRadius, groundLayer);
        isGrounded = colliders.Length > 0;

        if (!isGrounded)
        {
            RaycastHit hit;
            if (Physics.SphereCast(transform.position, sphereRadius, Vector3.down, out hit, sphereCastDistance, groundLayer))
            {
                isGrounded = true;
                Debug.Log("Ray_Grounded");
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.layer & groundLayer.value) > 0)
        {
            isGrounded = true;
            Debug.Log("Enter");
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if ((collision.gameObject.layer & groundLayer.value) > 0)
        {
            isGrounded = true;
            Debug.Log("Stay");
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if ((collision.gameObject.layer & groundLayer.value) > 0)
        {
            isGrounded = false;
            Debug.Log("Exit");
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Vector3 spherePos = transform.position + Vector3.up * sphereOffset;
        Gizmos.DrawWireSphere(spherePos, sphereRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.down * sphereCastDistance);
    }
}
