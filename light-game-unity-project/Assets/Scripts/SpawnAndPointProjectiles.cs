using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnAndPointProjectiles : MonoBehaviour
{
    public GameObject projectilePrefab; // Reference to the projectile prefab to be spawned
    public Transform triangleRotation;
    public float spawnInterval = 1.0f;   // Time interval between spawning projectiles
    public float pointsToSpawnProjectiles = 4;

    private float lastSpawnTime = 0.0f;
    private GameObject currentProjectile;
    private Transform circleTransform;
    private TriangleCollision triangleCollision;
    private EnemySpawner enemySpawner;
    private LightCalculator lightCalculator;

    private void Start()
    {
        enemySpawner = EnemySpawner.Instance;
        circleTransform = GameObject.Find("Circle")?.transform;
        triangleCollision = GameObject.Find("Light").GetComponent<TriangleCollision>();
        lightCalculator = GameObject.Find("Light").GetComponent<LightCalculator>();
        if (circleTransform == null)
        {
            Debug.LogError("Could not find 'Circle' gameObject's transform.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastSpawnTime >= spawnInterval &&
            triangleCollision.hasCollided == true && enemySpawner.currentEnemyCount >= pointsToSpawnProjectiles &&
            lightCalculator.won == false)
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

            // Update the last spawn time
            lastSpawnTime = Time.time;
        }
    }
}
