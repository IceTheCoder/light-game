using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderRadiusFromLightRadius : MonoBehaviour
{
    CircleCollider2D circleCollider;
    UnityEngine.Rendering.Universal.Light2D theLight;

    /// <summary>
    /// Called when the script is first loaded, this method gets the circle collider and light 2d components
    /// of the players and placed them in 2 variabled.
    /// </summary>
    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        theLight = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
    
    }

    /// <summary>
    /// Called once per frame, this function sets the circle collider's radius to match the light's outer
    /// radius.
    /// </summary>
    void Update()
    {
        circleCollider.radius = theLight.pointLightOuterRadius;
    }
}
