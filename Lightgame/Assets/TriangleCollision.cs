using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TriangleCollision : MonoBehaviour
{
    public LightCalculator lightCalculator;
    public float health; 
    public float healthChange;

    void Start() {
        health = 1f;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Triangle")
        {
            // lightCalculator.enabled = false;
            float[] health0 = new float[] {health - healthChange, 0f};
            health = health0.Max();
        }
    }
    void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.tag == "Triangle") {
            lightCalculator.enabled = true;
        }
    }
}
