using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Light"))
        {
            Debug.Log("Hey! Health!");
        }
    }

}
