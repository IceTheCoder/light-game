using UnityEngine;
using System.Collections;

public class Speedometer : MonoBehaviour
{
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
}
