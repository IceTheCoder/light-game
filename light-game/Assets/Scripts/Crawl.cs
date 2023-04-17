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
    /// Called once per frame, this method generates a random Vector2
    /// The position of the game object is then updated by adding the random
    /// Vector2 to the current position, resulting in a 'crawling' effect.
    /// </summary>
    void Update()
    {
        Vector2 movement = Random.insideUnitCircle * magnitude;

        // Move the object in the direction of the random Vector2
        transform.position += new Vector3(movement.x, movement.y, 0) * speed * Time.deltaTime;
    }
}
