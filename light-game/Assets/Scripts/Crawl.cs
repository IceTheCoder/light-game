using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crawl : MonoBehaviour
{
    // Speed of movement
    public float speed = 50f;
    // Magnitude of movement
    public float magnitude = 0.1f;

    /// <summary>
    /// Called once per frame, this method calculates a random Vector2 and uses it to change the position
    /// of the triangle, giving it a 'crawling' effect.
    /// </summary>
    void Update()
    {
        // Generate a random Vector2 with magnitude less than or equal to 0.5
        Vector2 movement = Random.insideUnitCircle * magnitude;

        // Move the object in the direction of the random Vector2
        transform.position += new Vector3(movement.x, movement.y, 0) * speed * Time.deltaTime;
    }
}
