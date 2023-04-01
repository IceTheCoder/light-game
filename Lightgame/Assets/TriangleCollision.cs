using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleCollision : MonoBehaviour
{
    public LightCalculator lightCalculator;

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Triangle")
        {
            lightCalculator.enabled = false;
        }
    }
}
