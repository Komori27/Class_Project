using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform player;


    public bool isFlipped = false;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
            Debug.Log("NoFlip");
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
            Debug.Log("Flip");

        }
    }
}