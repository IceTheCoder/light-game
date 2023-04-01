using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Triangle")
        {
            // Collision detected between the 'Light' and 'Triangle' objects.
            // Do something here, like destroy the 'Triangle' object.
            Debug.Log("Collision detected!");
        }
    }
}
