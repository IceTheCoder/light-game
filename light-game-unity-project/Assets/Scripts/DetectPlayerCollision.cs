using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class DetectPlayerCollision : MonoBehaviour
{
    public float secondsOfText = 1f;

    public EnableObject enableObject;
    public DisableObject disableObject;
    public ShowText showText;

    /// <summary>
    /// Called upon collision with another trigger object, this method checks if the object is the Light,
    /// and if that's the case, the method enables the equipped sword underneath the Light,
    /// shows the text '+1 Sword' for 1 second, and disables the sword item, through various other scripts
    /// and their methods.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Light"))
        {
            enableObject.Enable();
            showText.Show();
            StartCoroutine(HideText());
        }
    }

    IEnumerator HideText()
    {
        yield return new WaitForSeconds(secondsOfText);
        showText.Hide();
        disableObject.Disable();
    }
}
