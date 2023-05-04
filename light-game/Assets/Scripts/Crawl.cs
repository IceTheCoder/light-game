using UnityEngine;

public class Crawl : MonoBehaviour
{
    public float speed = 2.5f;
    public float magnitude = 0.2f;
    public float overlapRadius = 0.1f;

    private Vector2 startPosition;
    private Vector2 targetPosition;

    /// <summary>
    /// Called when the script firt runs,
    /// this mehotd initializes variables for the starting (current of the object) position, 
    /// target position (the position to slide towards), 
    /// and a new array of colliders with a length of one.
    /// </summary>
    void Start()
    {
        startPosition = transform.position;
        targetPosition = GetRandomTargetPosition();
    }

    /// <summary>
    /// Called once per frame,
    /// this method first checks if the object is touching a triangles, 
    /// and sets a new target position if it is,
    /// then it moves the object towards the target position based on the speed float,
    /// and if it gets close to the target position, it chooses a news one.
    /// This method also limits the target poistion to the boundaries of the scene.
    /// </summary>
    void Update()
    {
        Vector2 newPosition = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector2.Distance(newPosition, targetPosition) < overlapRadius)
        {
            targetPosition = GetRandomTargetPosition();
        }

        // Clamp the target position to the boundaries of the scene
        float minX = Camera.main.ScreenToWorldPoint(Vector3.zero).x;
        float maxX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        float minY = Camera.main.ScreenToWorldPoint(Vector3.zero).y;
        float maxY = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);
        targetPosition.y = Mathf.Clamp(targetPosition.y, minY, maxY);

        transform.position = newPosition;
    }

    /// <summary>
    /// Called once the object is near a collider or near the target position, 
    /// this method generates a new target position for the object within a circle with the radius of the maginute float, 
    /// until the position is not near a collider.
    /// </summary>
    /// <returns>Vector2 target position</returns>
    private Vector2 GetRandomTargetPosition()
    {
        Vector2 position = startPosition + Random.insideUnitCircle * magnitude;

        return position;
    }
}
