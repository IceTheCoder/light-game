using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderRadiusFromLightRadius : MonoBehaviour
{
    CircleCollider2D circleCollider;
    UnityEngine.Rendering.Universal.Light2D theLight;

    /// <summary>
    /// 
    /// </summary>
    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        theLight = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
    
    }

    // Update is called once per frame
    void Update()
    {
        circleCollider.radius = theLight.pointLightOuterRadius;
    }
}
