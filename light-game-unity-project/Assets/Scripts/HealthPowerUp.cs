using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    public TriangleCollision triangleCollision;
    public LightCalculator lightCalculator;
    public float destroyDelay = 1f;

    /// <summary>
    /// Called when the health power-up collides with the light,
    /// this function sets the health to 1, calls the UpdateText method of TriangleCollision
    /// (to make the health text blue for 1 second), and destroys the power-up after 1 second.
    /// </summary>
    /// <param name="collision"></param>
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Light") && lightCalculator.won == false)
        {
            triangleCollision.health = 1f;
            triangleCollision.UpdateText(true);
            Destroy(gameObject, destroyDelay);
        }
    }

}
