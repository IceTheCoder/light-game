using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleCollision : MonoBehaviour
{
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Triangle")
        {
            Debug.Log("Collision detected!");
        }
    }
}
