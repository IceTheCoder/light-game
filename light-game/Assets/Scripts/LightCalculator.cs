// https://youtu.be/tJfJOMIMglE
using UnityEngine;
// https://forum.unity.com/threads/the-type-or-namespace-name-ienumerator-could-not-be-found.1310867/
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class LightCalculator : MonoBehaviour
{
    private UnityEngine.Rendering.Universal.Light2D theLight;
    public float speed = 0.2f;
    public float speedFactor = 0.07f;
    public TriangleCollision collision;
    public float lightChangeDelay = 1f;

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

            yield return new WaitForSeconds(0.01f);

            float currentSpeed = Vector3.Distance(transform.position, prevPos) / Time.fixedDeltaTime;
            Debug.Log(Vector3.Distance(transform.position, prevPos));
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

    /// <summary>
    /// Called every fixed frame, this function sets the intensity of the light to 0.34 or the
    /// speed multiplied by the speedFactor multiplied by health, whichever is bigger, and the
    /// radius of it to 0.2 or the speed multiplied by the speedFactor multiplied by health,
    /// whichever is bigger.
    /// </summary>
    void FixedUpdate()
    {
        // Force a minimum intensity of 1 and a minimum radius of 0.2 for the light.
        float[] intensityValues = { speed * speedFactor * collision.health, 0.34f };
        float[] radiusValues = { speed * speedFactor * collision.health, 0.2f };
        theLight.intensity = intensityValues.Max();
        theLight.pointLightOuterRadius = radiusValues.Max();
    }
}
