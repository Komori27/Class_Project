using UnityEngine;

public class Dodge : MonoBehaviour
{
    public float dodgeDistance = 3f;
    public float dodgeTime = 0.5f;
    public float dodgeWidth = 0.5f;
    public SpriteRenderer spriteRenderer;

    public bool isDodging = false;

        public bool IsDodging
    {
        get { return isDodging; }
    }
    public void DodgeLeft()
    {
        DodgeDirection(-1);
    }

    public void DodgeRight()
    {
        DodgeDirection(1);
    }

    public void DodgeDirection(int direction)
    {
        if (!isDodging)
        {
            isDodging = true;

            // Set collider to be a trigger to allow movement through other colliders
            Collider2D collider = GetComponent<Collider2D>();
            collider.isTrigger = true;

            if (direction == 0)
            {
                // No directional key pressed, dodge in current facing direction
                direction = spriteRenderer.flipX ? -1 : 1;
            }
           
            Vector3 dodgePosition = transform.position + new Vector3(dodgeDistance * direction, 0, 0);
            Vector2 size = new Vector2(dodgeWidth, collider.bounds.size.y);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(dodgePosition, size, 0, LayerMask.GetMask("Wall"));
            
            if (colliders.Length > 0)
            {
                // Cancel the dodge if there are walls in the way
                isDodging = false;
                collider.isTrigger = false;
                return;
            }

            // Calculate the dodge path and move the player
            Vector3 startPosition = transform.position;
            transform.position = dodgePosition;

            // Calculate the dodge path and check for any colliders in the way
            RaycastHit2D hit = Physics2D.Raycast(dodgePosition, Vector2.right * direction, dodgeDistance, LayerMask.GetMask("Wall"));

            if (direction < 0)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }

            if (!hit)
            {
                // Move the player if there are no colliders in the way
                transform.position = dodgePosition;

                // Flip the player sprite to face the dodge direction
                SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
                if (direction < 0)
                {
                    spriteRenderer.flipX = true;
                }
                else
                {
                    spriteRenderer.flipX = false;
                }
            }
            else
            {
                // Move the player to the edge of the collider if there is one in the way
                float offset = (hit.distance / 2 + dodgeWidth / 2) * direction;
                Vector3 newDodgePosition = hit.point + new Vector2(offset, 0);
                transform.position = newDodgePosition;
            }

            // Reset collider to be a solid collider after the dodge time has passed
            Invoke("ResetDodge", dodgeTime);
        }
    }


    private void ResetDodge()
    {
        // Set collider to be a solid collider
        Collider2D collider = GetComponent<Collider2D>();
        collider.isTrigger = false;

        isDodging = false;
    }
}
