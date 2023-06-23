using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObject : MonoBehaviour
{
    // This should be sword item that should be disabled after picked up.
    public GameObject obj;

    /// <summary>
    /// Called when the player picks up the sword, this method disables the referenced object
    /// (which should be the sword item).
    /// </summary>
    public void Disable()
    {
        obj.SetActive(false);
    }
}
