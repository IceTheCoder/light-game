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
    public float lightChangeDelay = 0.6f;

    // Number of previous speed samples to include in the moving average
    public int numSamples = 10;

    // List of previous speed samples
    private List<float> speedSamples = new List<float>();

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.2f;
        
        theLight = GetComponent<UnityEngine.Rendering.Universal.Light2D>();

        StartCoroutine(CalcSpeed());
    }

    IEnumerator CalcSpeed()
    {
        speed = 0.2f;

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
            
            //if (transform.position == prevPos)
            //{
            //    speed = 0.2f;
            //}
        }
    }


    void FixedUpdate()
    {
        // Force a minimum intensity of 1 and a minimum radius of 0.2 for the light.
        float[] intensityValues = { speed * speedFactor * collision.health, 0.34f };
        float[] radiusValues = { speed * speedFactor * collision.health, 0.2f };
        theLight.intensity = intensityValues.Max();
        theLight.pointLightOuterRadius = radiusValues.Max();

        // Debug.Log(speed);
    }
}
