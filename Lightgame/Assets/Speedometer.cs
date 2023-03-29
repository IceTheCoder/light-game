// https://youtu.be/tJfJOMIMglE
using UnityEngine;
// https://forum.unity.com/threads/the-type-or-namespace-name-ienumerator-could-not-be-found.1310867/
using System.Collections;
using System.Collections.Generic;

public class Speedometer : MonoBehaviour
{
    private UnityEngine.Rendering.Universal.Light2D light;
    public float speed;

    // Number of previous speed samples to include in the moving average
    public int numSamples = 10;

    // List of previous speed samples
    private List<float> speedSamples = new List<float>();

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        StartCoroutine(CalcSpeed());
    }

    IEnumerator CalcSpeed()
    {
        bool isPlaying = true;

        while (isPlaying) 
        {
            Vector3 prevPos = transform.position;

            yield return new WaitForFixedUpdate();

            // Calculate speed and add to list of speed samples
            float currentSpeed = Vector3.Distance(transform.position, prevPos) / Time.fixedDeltaTime;
            speedSamples.Add(currentSpeed);

            // If number of samples exceeds limit, remove oldest sample
            if (speedSamples.Count > numSamples) {
                speedSamples.RemoveAt(0);
            }

            // Calculate average speed over previous samples
            float totalSpeed = 0f;
            foreach (float sample in speedSamples) {
                totalSpeed += sample;
            }
            speed = totalSpeed / speedSamples.Count;
        }
    }

    void FixedUpdate()
    {
        light.intensity = speed / 5;
        light.pointLightOuterRadius = speed / 5;
    }
}
