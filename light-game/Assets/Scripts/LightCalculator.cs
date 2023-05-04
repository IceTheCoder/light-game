// https://youtu.be/tJfJOMIMglE
using UnityEngine;
// https://forum.unity.com/threads/the-type-or-namespace-name-ienumerator-could-not-be-found.1310867/
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class LightCalculator : MonoBehaviour
{
    public float speed = 0.2f;
    public float speedFactor = 0.07f;
    public float lightUpdateDelay = 0.01f;
    public float minimumIntensity = 0.34f;
    public float minimumRadius = 0.2f;
    public float lightChangeDelay = 1f;
    public bool won = false;
    public TriangleCollision collision;
    public FollowMouse followMouseScript;
    private UnityEngine.Rendering.Universal.Light2D theLight;

    // Number of previous speed samples to include in the moving average
    public int numSamples = 10;

    // List of previous speed samples
    private List<float> speedSamples = new List<float>();

    /// <summary>
    /// Called when the Script is loaded, this method sets the speed to 0.2, gets the light 2D component,
    /// and starts the CalcSpeed coroutine.
    /// </summary>
    void Start()
    {
        speed = 0.2f;
        
        theLight = GetComponent<UnityEngine.Rendering.Universal.Light2D>();

        StartCoroutine(CalcSpeed());
    }

    /// <summary>
    /// Called when the script is first loaded, this coroutine waits for the lightChangeDelay to pass,
    /// then continously calculates the distance between the current position and the position 0.01 seconds
    /// ago, and divides this distance by fixedDeltaTime to get a speed, which it adds to a list of a
    /// maximum of 10 samples, which are averaged to determine the smooth speed of the light.
    /// </summary>
    /// <returns>Absolutely nothing.</returns>
    IEnumerator CalcSpeed()
    {
        yield return new WaitForSeconds(lightChangeDelay);

        while (true)
        {

            Vector3 prevPos = transform.position;

            yield return new WaitForSeconds(lightUpdateDelay);

            float currentSpeed = Vector3.Distance(transform.position, prevPos) / Time.fixedDeltaTime;
            
            if (currentSpeed < 50) {
                speedSamples.Add(currentSpeed);

                if (speedSamples.Count > numSamples)
                {
                    speedSamples.RemoveAt(0);
                }

                float totalSpeed = 0f;
                foreach (float sample in speedSamples)
                {
                    totalSpeed += sample;
                }
                speed = totalSpeed / speedSamples.Count;
            }
        }
    }

    /// <summary>
    /// Called every fixed frame, this function sets the intensity of the light to 0.34 or the
    /// speed multiplied by the speedFactor multiplied by health, whichever is bigger, and the
    /// radius of it to 0.2 or the speed multiplied by the speedFactor multiplied by health,
    /// whichever is bigger.
    /// </summary>
    void FixedUpdate()
    {
        if (won == false)
        {
            // Force a minimum intensity of 0.34 and a minimum radius of 0.2 for the light.
            float[] intensityValues = { speed * speedFactor * collision.health, minimumIntensity };
            float[] radiusValues = { speed * speedFactor * collision.health, minimumRadius };
            theLight.intensity = intensityValues.Max();
            theLight.pointLightOuterRadius = radiusValues.Max();
        } else
        {
            followMouseScript.enabled = false;
            theLight.pointLightOuterRadius += 0.2f;
        }
    }
}
