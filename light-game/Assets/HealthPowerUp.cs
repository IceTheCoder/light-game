using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    public TriangleCollision triangleCollision;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Light"))
        {
            triangleCollision.health = 1f;
            triangleCollision.UpdateText(true);
            Destroy(gameObject, 1f);
        }
    }

}
