using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableObject : MonoBehaviour
{
    // Should be the player's equipped sword to be enabled after the sword item is picked up.
    public GameObject obj;

    /// <summary>
    /// Called when the player picks up the sword, this method enables the equipped sword of the player.
    /// </summary>
    public void Enable()
    {
        obj.SetActive(true);
    }

}
