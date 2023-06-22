using UnityEngine;


public class CollisionHandler : MonoBehaviour
{
    public int maxLives = 3; // Maximum number of lives for the player
    private int currentLives; // Current number of lives for the player
    private LivesUI livesUI;

    private void Start()
    {
        livesUI = FindObjectOfType<LivesUI>();
        currentLives = maxLives; // Initialize lives at the start
        livesUI.UpdateLivesUI(currentLives);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fish"))
        {
            currentLives--;
            
            if (currentLives <= 0)
            {
                // Player is out of lives, handle game over logic here
            }
            else
            {
                // Player still has lives, handle life lost logic here
            }

            livesUI.UpdateLivesUI(currentLives);
        }
    }
}