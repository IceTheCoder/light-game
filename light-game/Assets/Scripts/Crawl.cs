using UnityEngine;

public class Crawl : MonoBehaviour
{
    public float speed = 2f;
    public float overlapRadius = 0.5f;

    private Vector2 targetPosition;
    private Collider2D[] colliders = new Collider2D[10];

    void Start()
    {
        targetPosition = GetRandomTargetPosition();
    }

    void Update()
    {
        if (Physics2D.OverlapCircleNonAlloc(transform.position, overlapRadius, colliders) > 0)
        {
            targetPosition = GetRandomTargetPosition();
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            targetPosition = GetRandomTargetPosition();
        }
    }

    private Vector2 GetRandomTargetPosition()
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        float distance = Random.Range(1f, 3f);
        return (Vector2)transform.position + (randomDirection * distance);
    }
}
