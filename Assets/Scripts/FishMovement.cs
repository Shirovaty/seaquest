using UnityEngine;

public class FishMovement : MonoBehaviour
{
    private Vector3 movementDirection;
    private float movementSpeed;
    private float despawnXPosition;
    private bool flipSprite;
    private FishSpawner fishSpawner;
    private Rigidbody2D rb; 
    private SpriteRenderer spriteRenderer;

    public void SetMovement(Vector3 direction, float speed, float despawnX, bool flip)
    {
        movementDirection = direction;
        movementSpeed = speed;
        despawnXPosition = despawnX;
        flipSprite = flip;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        fishSpawner = FindObjectOfType<FishSpawner>(); // Find the FishSpawner in the scene
    }

    void Update()
    {
        transform.Translate(movementDirection * movementSpeed * Time.deltaTime);

        if(flipSprite)
        {
            spriteRenderer.flipX = true;
        }

        // Check if the fish has moved past the despawn X position
        if ((movementDirection.x < 0 && transform.position.x < despawnXPosition) ||
            (movementDirection.x > 0 && transform.position.x > despawnXPosition))
        {
            fishSpawner.DecreaseActiveFishCount(); // Decrease the active fish count in the FishSpawner
            Destroy(gameObject); // Destroy the fish object
        }
    }
}