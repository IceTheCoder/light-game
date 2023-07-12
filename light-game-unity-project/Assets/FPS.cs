using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS : MonoBehaviour
{
    void Start()
    {
        // Make the game run as fast as possible
        //Application.targetFrameRate = -1;
        // Limit the framerate to 60
        Application.targetFrameRate = 60;

    }
}
