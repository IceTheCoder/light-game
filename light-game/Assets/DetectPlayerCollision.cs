using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DetectPlayerCollision : MonoBehaviour
{
    public EnableObject enableObject;
    public DisableObject disableObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Light"))
        {
            enableObject.Enable();
            disableObject.Disable();
        }

    }
}
