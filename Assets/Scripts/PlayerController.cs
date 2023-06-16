using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float xmin = -10.5f;
    public float xmax = 10.5f;
    public float ymin = -2.65f;
    public float ymax = 3.35f;
    private Rigidbody2D rb; 
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput) * moveSpeed;
        rb.velocity = movement;

        // Flip the sprite based on the movement direction
        if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true; // Flip the sprite horizontally
        }
        else if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false; // Reset the sprite's flipping
        }

        // Apply boundary constraints  
        float clampedX = Mathf.Clamp(rb.position.x, xmin, xmax);
        float clampedY = Mathf.Clamp(rb.position.y, ymin, ymax);
        rb.position = new Vector2(clampedX, clampedY);
        
    }

    
}
