using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class TriangleCollision : MonoBehaviour
{
    public float health = 0f;

    [Tooltip("Only for normal triangles. Stronger triangles one-shot kill.")]
    public float healthChange = 0.1f;
    public float collisionDelay = 1f;
    public float minHealth = 0.1f;
    public float healthChangeColourLength = 1f;

    [Tooltip("Only for stronger triangles.")]
    public float secondsUntilSwordCooldownStarts = 0.25f;

    [Tooltip("Only for stronger triangles.")]
    public float secondsOfSwordCooldown = 1f;

    public GameObject gameOverPanel;
    public GameObject equippedSword;
    public TextMeshProUGUI textBox;
    public ShowText showText;

    bool dead;
    bool canCollide = false;

    [Tooltip("Only for stronger triangles.")]
    public bool swordCooldown = false;
    private UnityEngine.Rendering.Universal.Light2D theLight;

    // Reference the placeholder's transform

    /// <summary>
    /// Called when the script first runs, this method sets dead to false, health to 1 and starts
    /// the CollisionDelay coroutine.
    /// </summary>
    void Start()
    {
        dead = false;
        health = 1f;
        StartCoroutine(CollisionDelay());
        theLight = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
    }

    /// <summary>
    /// Called once per frame, this method constantly checks if the health reached 0, and uses the
    /// dead bool to activate the gameOverPanel only once. It also sets the health to 0 if it's below
    /// 0.1.
    /// </summary>
    private void Update()
    {
        if (health == 0)
        {
            theLight.pointLightOuterRadius = 0f;
            theLight.intensity = 0f;

            if (!dead)
            {
                gameOverPanel.SetActive(true);
                if (EnemySpawner.Instance)
                {
                    if (EnemySpawner.Instance.currentDifficulty > 1)
                    {
                        EnemySpawner.Instance.currentDifficulty = 1;
                    }
                    EnemySpawner.Instance.currentEnemyCount = 0;
                }
                dead = true;
            }
        }
    }

    /// <summary>
    /// This coroutine waits for the collisionDelay to pass, and then sets the canCollide bool to true,
    /// in order to allow object collision.
    /// </summary>
    /// <returns>Nothing.</returns>
    IEnumerator CollisionDelay()
    {
        yield return new WaitForSeconds(collisionDelay);
        canCollide = true;
    }

    /// <summary>
    /// Called once per frame, this method checks if the object
    /// is touching the triangle and canCollide, and changes the
    /// health to 0 or to health - healthChange (so the health decreases when colliding with a triangle
    /// and it can't go below 0) and updates the text box displaying the health value accordingly.
    /// If the triangle is stronger, the health is set to 0, unless the player has a sword equipped,
    /// in which case hitSrtongerTriangle in the Crawl scripts of the StrongerTriangles is set to true,
    /// making them start to crawl.
    /// </summary>
    /// <param name="collision"></param>
    void OnTriggerStay2D(Collider2D collision)
    {
        if (equippedSword.activeSelf == false || (equippedSword.activeSelf && swordCooldown == true))
        {
            if (collision.CompareTag("Triangle") && canCollide)
            {
                float[] health0 = new float[] { health - healthChange, 0f };
                health = health0.Max();
                UpdateText(false);
                // Set the placeholder's position to the player's position.
            }
            if (collision.CompareTag("StrongerTriangle") && canCollide)
            {
                health = 0f;
                UpdateText(false);
            }
        } else if (collision.CompareTag("StrongerTriangle") && canCollide && swordCooldown == false)
        {
            Crawl[] crawl = FindObjectsOfType<Crawl>();
            foreach (Crawl script in crawl)
            {
                script.hitStrongerTriangle = true;
            }
            showText.Show();

            // Find the only child game object of the object that the script sits on
            GameObject otherObject = transform.GetChild(0).gameObject;

            // Calculate the angle between the otherObject and the triangle
            Vector3 direction = collision.transform.position - otherObject.transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            angle += 180;

            // Rotate only the Z-axis of the otherObject towards the triangle
            otherObject.transform.rotation = Quaternion.Euler(0, 0, angle);

            StartCoroutine(WaitBeforeSwordCooldown());
        }

    }

    IEnumerator WaitBeforeSwordCooldown()
    {
        yield return new WaitForSeconds(secondsUntilSwordCooldownStarts);
        StartCoroutine(SwordCooldown());
    }

    IEnumerator SwordCooldown()
    {
        swordCooldown = true;
        yield return new WaitForSeconds(secondsOfSwordCooldown);
        swordCooldown = false;
        showText.Hide();
    }

    /// <summary>
    /// Called when the health needs to be updated (when the light collides with the triangle),
    /// this method updates the health text to display from 1 to 10 (if the health is 0.1, it'll be displayed as 1,
    /// if it's 1, it'll be displayed as 10).
    /// </summary>
    public void UpdateText(bool heal)
    {
        textBox.text = "Health: " + (health * 10f).ToString("0");
        StartCoroutine(ColorChange(heal));
    }

    /// <summary>
    /// Called when the health increases or decrease, this coroutine changes its color to
    /// blue or red, respectively, for 1 second.
    /// </summary>
    /// <param name="heal">Whether or not the health change comes from a health power-up.</param>
    /// <returns></returns>
    IEnumerator ColorChange(bool heal)
    {
        if (heal == true)
        {
            textBox.color = Color.green;
        }
        else
        {
            textBox.color = Color.red;
        }
        yield return new WaitForSeconds(healthChangeColourLength);
        textBox.color = Color.white;
    }
}
