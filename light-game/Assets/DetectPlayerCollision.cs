using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DetectPlayerCollision : MonoBehaviour
{
    public EnableObject enableObject;
    public DisableObject disableObject;
    public ShowTextFor1Sec showTextFor1Sec;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Light"))
        {
            enableObject.Enable();
            showTextFor1Sec.Show();
            disableObject.Disable();
        }

    }
}
