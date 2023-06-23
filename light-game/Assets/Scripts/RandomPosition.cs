using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPosition : MonoBehaviour
{
    // Set the boundaries of the screen
    private float screenWidth;
    private float screenHeight;

    // The object('s transform) to be moved
    private Transform objectToMove;

    /// <summary>
    /// Called when the script first loads, this method gets the screen width and height 
    /// and the object's transform component, and also calls the function to move the object to a random position.
    /// </summary>
    void Start()
    {
        // Get the screen dimensions
        screenWidth = Screen.width;
        screenHeight = Screen.height;

        // Get the object to move
        objectToMove = GetComponent<Transform>();

        // Call the function to move the object
        MoveObject();
    }

    /// <summary>
    /// Called shortly after the script first loads, this metho gets a random position within the scene view,
    /// and moves the object to that position.
    /// </summary>
    void MoveObject()
    {
        // Set a random position within the screen view
        float randomX = Random.Range(0, screenWidth);
        float randomY = Random.Range(0, screenHeight);
        Vector3 randomPosition = Camera.main.ScreenToWorldPoint(new Vector3(randomX, randomY, 0));
        randomPosition.z = -0.1f; // Set the Z coordinate to -0.1

        // Move the object to the random position
        objectToMove.position = randomPosition;
    }
}
