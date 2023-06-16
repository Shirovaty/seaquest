using UnityEngine;

public class FishMovement : MonoBehaviour
{
    private Vector3 movementDirection;
    private float movementSpeed;
    private float despawnXPosition;
    private bool flipSprite;
    private Rigidbody2D rb; 
    private SpriteRenderer spriteRenderer;

    public void SetMovement(Vector3 direction, float speed, float despawnX, bool flip)
    {
        movementDirection = direction.normalized;
        movementSpeed = speed;
        despawnXPosition = despawnX;
        flipSprite = flip;

        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if(flipSprite){
            spriteRenderer.flipX = true;
        }
    }

    void Update()
    {
        // Move the fish in the set direction and speed
        transform.Translate(movementDirection * movementSpeed * Time.deltaTime);

        // Check if the fish has reached the despawn position
        if(flipSprite){
            if (transform.position.x > despawnXPosition)
            {
                Destroy(gameObject);
            }
        }else{
            if (transform.position.x < despawnXPosition)
            {
                Destroy(gameObject);
            }
        }
        
    }
}
