using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 10f; // Speed of the bullet
    public Vector3 movementDirection;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed; // Set initial velocity to move the bullet horizontally
    }

    public void SetMovement(Vector3 direction)
    {
        movementDirection = direction.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movementDirection * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the bullet collides with an enemy
        FishMovement enemy = collision.GetComponent<FishMovement>();
        if (enemy != null)
        {
            Destroy(gameObject); // Destroy the bullet
        }
    }
}
