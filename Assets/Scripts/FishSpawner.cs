using System;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public GameObject fishPrefab;
    public int fishCount = 1;
    public float spawnRate = 2f;
    public float fishSpeed = 2f;
    public float spawnAreaY = -2.2f;
    public float spawnXPosition = -14f;
    public float despawnXPosition = 14f;
    public System.Random random = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        // Start spawning fish at regular intervals
        InvokeRepeating("SpawnFish", spawnRate, spawnRate);
    }

    void SpawnFish()
    {
        for (int i = 0; i < fishCount; i++)
        {         

            // Determine the side of the screen to spawn the fish
            int side = random.Next(0, 2); // Generate a random number between 0 and 3
            Vector3 movementDirection;
            bool flipSprite = false;

            // Calculate the x position based on the side
            float xPosition;
            if (side == 0) // Spawn on the left side
            {
                xPosition = spawnXPosition;
                movementDirection = Vector3.right;
                flipSprite = true;
            } 
            else // Spawn on the right side
            {
                xPosition = despawnXPosition;
                movementDirection = Vector3.left;
            } 

            // Instantiate a fish at the spawn position
            GameObject fish = Instantiate(fishPrefab, new Vector3(xPosition, spawnAreaY, 0f), Quaternion.identity);

            // Set the fish's movement towards the other side
            FishMovement fishMovement = fish.GetComponent<FishMovement>();
            if(xPosition == spawnXPosition){
                fishMovement.SetMovement(movementDirection, fishSpeed, despawnXPosition, flipSprite);
            }else{
                fishMovement.SetMovement(movementDirection, fishSpeed, spawnXPosition, flipSprite);
            }
            
        }
    }
}
