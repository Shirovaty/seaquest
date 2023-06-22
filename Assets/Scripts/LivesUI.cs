using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    public Image heartImagePrefab; // Prefab of the heart image
    public Transform heartContainer; // Parent transform for the heart images

    public Sprite filledHeartSprite; // Sprite for a remaining life
    public Sprite emptyHeartSprite; // Sprite for a lost life

    private int currentLives; // Current number of lives for the player
    private int maxLives = 3;

    // Call this method to update the lives UI with the current number of lives
    public void UpdateLivesUI(int lives)
    {
        // Remove all existing heart images
        foreach (Transform child in heartContainer)
        {
            if (child != null)
            {
                Destroy(child.gameObject);
            }
        }

        // Create new heart images based on the current number of lives
        for (int i = 0; i < lives; i++)
        {
            Image heartImage = Instantiate(heartImagePrefab, heartContainer);
            heartImage.sprite = (i < lives) ? filledHeartSprite : emptyHeartSprite;
        }

        // Create empty heart images for lost lives
        for (int i = lives; i < maxLives; i++)
        {
            Image heartImage = Instantiate(heartImagePrefab, heartContainer);
            heartImage.sprite = emptyHeartSprite;
        }
    }
}