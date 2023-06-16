using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab of the bullet
    public Transform firePoint; // Point from where the bullet is spawned
    public Vector3 movementDirection;
    public float fireRate = 0.5f; // Time between each bullet spawn

    private float nextFireTime; // Time when the next bullet can be spawned
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFireTime)
        {
            SpawnBullet();
            nextFireTime = Time.time + fireRate;
        }

    }
    private void SpawnBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint);
        BulletMovement bulletComponent = bullet.GetComponent<BulletMovement>();
        bulletComponent.SetMovement(movementDirection);
        if (bulletComponent != null)
        {
            // Customize bullet properties if needed
            // bulletComponent.speed = ...;
            // bulletComponent.damage = ...;
        }
    }
}
