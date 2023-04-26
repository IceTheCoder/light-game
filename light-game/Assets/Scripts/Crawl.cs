using UnityEngine;

public class Crawl : MonoBehaviour
{
    public float speed = 2.5f;
    public float magnitude = 0.2f;
    public float overlapRadius = 0.1f;

    private Vector2 startPosition;
    private Vector2 targetPosition;

    private Collider2D[] colliders = new Collider2D[0];

    /// <summary>
    /// 
    /// </summary>
    void Start()
    {
        startPosition = transform.position;
        targetPosition = GetRandomTargetPosition();
        colliders = new Collider2D[1];
    }

    void Update()
    {
        if (Physics2D.OverlapCircleNonAlloc(targetPosition, overlapRadius, colliders) > 0)
        {
            targetPosition = GetRandomTargetPosition();
            return;
        }

        Vector2 newPosition = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector2.Distance(newPosition, targetPosition) < 0.1f)
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


    private Vector2 GetRandomTargetPosition()
    {
        Vector2 position = startPosition + Random.insideUnitCircle * magnitude;

        while (Physics2D.OverlapCircleNonAlloc(position, overlapRadius, colliders) > 0)
        {
            position = startPosition + Random.insideUnitCircle * magnitude;
        }

        return position;
    }
}
