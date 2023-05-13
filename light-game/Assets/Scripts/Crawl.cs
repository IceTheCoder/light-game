using UnityEngine;

public class Crawl : MonoBehaviour
{
    public float speed = 2.5f;
    public float magnitude = 0.2f;
    public float destinationOverlapRadius = 0.1f;
    public float squareOverlapRadius = 1.0f;

    public Transform square;

    private Vector2 startPosition;
    private Vector2 targetPosition;

    /// <summary>
    /// Called when the script firt runs,
    /// this mehotd initializes variables for the starting (current of the object) position, 
    /// target position (the position to slide towards), 
    /// </summary>
    void Start()
    {
        startPosition = transform.position;
        targetPosition = GetRandomTargetPosition();
    }

    /// <summary>
    /// Called once per frame,
    /// This method defines a new position (a gradual position between the current and target position).
    /// Then, it checks if the object is close to the target position and gets a new target position if so
    /// This method also limits the target poistion to the boundaries of the scene.
    /// </summary>
    void Update()
    {
        Vector2 newPosition = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector2.Distance(newPosition, targetPosition) < destinationOverlapRadius)
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
    /// Called once the object is near the target position, 
    /// this method generates a new target position for the object within a circle with the radius of the magnitude float.    
    /// </summary>
    /// <returns>Vector2 target position</returns>
    private Vector2 GetRandomTargetPosition()
    {
        Vector2 position;
        do
        {
            position = startPosition + Random.insideUnitCircle * magnitude;
        } while (Vector2.Distance(position, square.position) < squareOverlapRadius);

        return position;
    }
}
