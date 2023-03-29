// https://youtu.be/tJfJOMIMglE
using UnityEngine;
// https://forum.unity.com/threads/the-type-or-namespace-name-ienumerator-could-not-be-found.1310867/
using System.Collections;

public class Speedometer : MonoBehaviour
{
    public UnityEngine.Rendering.Universal.Light2D light;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CalcSpeed());
    }

    IEnumerator CalcSpeed()
    {
        bool isPlaying = true;

        while (isPlaying) 
        {
            Vector3 prevPos = transform.position;

            yield return new WaitForFixedUpdate();

            speed = Vector3.Distance(transform.position, prevPos) / Time.fixedDeltaTime;
        }
    }

    void FixedUpdate()
    {
        // shadowIntensity
        light.Intensity = speed;
        // light.m_PointLightOuterRadius = speed;
    }
}
