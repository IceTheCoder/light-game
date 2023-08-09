using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAndPointProjectiles : MonoBehaviour
{
    public GameObject projectilePrefab; // Reference to the projectile prefab to be spawned
    public Transform triangleRotation;
    public float spawnInterval = 1.0f;   // Time interval between spawning projectiles

    private float timer = 0.0f;
    private GameObject currentProjectile;
    private Transform circleTransform;
    
    void Start()
    {
        circleTransform = GameObject.Find("Circle")?.transform;
        if (circleTransform == null)
        {
            Debug.LogError("Could not find 'Circle' gameObject's transform.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // Update the rotation of the spawner to match the negative of triangleRotation.rotation
        //transform.rotation = Quaternion.Inverse(triangleRotation.rotation);

        if (currentProjectile == null)
        {
            // Spawn a projectile at the position of the spawner
            currentProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            if (circleTransform != null)
            {
                // Calculate the direction towards the 'Circle' gameObject
                Vector3 direction = circleTransform.position - currentProjectile.transform.position;

                // Rotate the projectile to point towards the calculated direction
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                currentProjectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }

            // Destroy the projectile after a set time
            Destroy(currentProjectile, 1.0f);

            // Reset the timer
            timer = 0.0f;
        }
    }
}
