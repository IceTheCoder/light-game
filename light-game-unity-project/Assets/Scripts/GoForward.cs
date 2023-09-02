using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoForward : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Adjust the speed as needed
    private TriangleCollision triangleCollision;

    private void Start()
    {
        triangleCollision = GameObject.Find("Light").GetComponent<TriangleCollision>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move the object upward based on its local up direction (Y-axis)
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

        // Check if the object has gone off-screen
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.x > Screen.width || screenPosition.x < 0)
        {
            // Destroy the object if it's off-screen
            Destroy(gameObject);
        }
        // Check if the object has gone off-screen on the y-axis
        if (screenPosition.y > Screen.height || screenPosition.y < 0)
        {
            // Destroy the object if it's off-screen on the y-axis
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Light"))
        {
            triangleCollision.health = Mathf.Max(triangleCollision.health - triangleCollision.healthChange, 0f);
            triangleCollision.UpdateText(false);
            Destroy(gameObject);
        }
    }

}
