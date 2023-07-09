using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderRadiusFromLightRadius : MonoBehaviour
{
    CircleCollider2D circleCollider;
    UnityEngine.Rendering.Universal.Light2D theLight;

    /// <summary>
    /// Get the circle collider and light 2D components when the script is loaded.
    /// </summary>
    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        theLight = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
    
    }

    /// <summary>
    /// Update the circle collider's radius to match the light's outer radius once per frame.
    /// </summary>
    void Update()
    {
        circleCollider.radius = theLight.pointLightOuterRadius;
    }
}
