using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoForward : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Adjust the speed as needed

    // Update is called once per frame
    void Update()
    {
        // Move the object upward based on its local up direction (Y-axis)
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }
}
