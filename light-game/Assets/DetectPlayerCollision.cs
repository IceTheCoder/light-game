using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DetectPlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Light"))
        {
            Debug.Log("You got the sword!");
        }

    }
}
