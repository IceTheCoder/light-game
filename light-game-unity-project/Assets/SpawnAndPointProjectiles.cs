using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAndPointProjectiles : MonoBehaviour
{
    public GameObject projectilePrefab; // Reference to the projectile prefab to be spawned
    public float spawnInterval = 1.0f;   // Time interval between spawning projectiles

    private float timer = 0.0f;
    private GameObject currentProjectile;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (currentProjectile == null && timer >= spawnInterval)
        {
            // Spawn a projectile at the position of the spawner
            currentProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            // Calculate the direction towards the (0, 0) coordinates
            Vector3 direction = new Vector3(0, 0, 0) - currentProjectile.transform.position;

            // Rotate the projectile to point towards the calculated direction
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            currentProjectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            // Destroy the projectile after a set time
            Destroy(currentProjectile, 1.0f);

            // Reset the timer
            timer = 0.0f;
        }
    }
}
