using System.Collections;
using UnityEngine;

public class Crawl : MonoBehaviour
{
    public float speed = 2f;
    public float magnitude = 8f;
    public float destinationOverlapRadius = 0.1f;

    /// <summary>
    /// Difficulty multiplier, the number to multiply by for each difficulty.
    /// </summary>
    [SerializeField] private float difficultyMultiplier = 1.05f;
    private Vector2 startPosition;
    private Vector2 targetPosition;
    private float defaultSpeed;
    [SerializeField] public bool hitStrongerTriangle = false;
    public bool crawling = false;

    private void Awake()
    {
        defaultSpeed = speed;
    }

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
    /// Called once per frame, this method runs the TriangleCrawl() method only if
    /// it's on a normal triangle.
    /// </summary>
    private void Update()
    {
        if (gameObject.CompareTag("Triangle") || (gameObject.CompareTag("StrongerTriangle") && hitStrongerTriangle))
        {
            TriangleCrawl();
        }
    }

    /// <summary>
    /// Called once per frame by the Update() method if on a normal triangle,
    /// This method defines a new position (a gradual position between the current and target position).
    /// Then, it checks if the object is close to the target position and gets a new target position if so
    /// This method also limits the target poistion to the boundaries of the scene.
    /// </summary>
    public void TriangleCrawl()
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
        return startPosition + Random.insideUnitCircle * magnitude;
    }

    /// <summary>
    /// Calling this will change the difficulty of the enemy.
    /// </summary>
    /// <param name="difficulty">difficulty should be a non-negative and non-zero number</param>
    public void SetDifficulty(int difficulty)
    {
        if (difficulty <= 0)
        {
            Debug.LogError("Cannot set difficulty to " + difficulty);
            return;
        }

        if (difficulty == 1) { speed = defaultSpeed; return; }

        speed = defaultSpeed * (difficulty - 1) * difficultyMultiplier;
    }
}
