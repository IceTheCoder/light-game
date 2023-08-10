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
