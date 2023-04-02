using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class TriangleCollision : MonoBehaviour
{
    public LightCalculator lightCalculator;
    public float health; 
    public float healthChange;
    public TextMeshProUGUI textMeshProUGUI;

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
            textMeshProUGUI.text = "Health: " + (health * 100).ToString("0");
        }
    }
    void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.tag == "Triangle") {
            lightCalculator.enabled = true;
        }
    }
}
