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

    public Transform placeholder;
    private Vector3 placeholderPos;

    /// <summary>
    /// Called when the script first runs, this method sets dead to false, health to 1, starts
    /// the CollisionDelay coroutine.
    /// </summary>
    void Start()
    {
        dead = false;
        health = 1f;
        StartCoroutine(CollisionDelay());
        theLight = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        placeholderPos = placeholder.position;
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
    /// Handles collision interactions with triangles and stronger triangles. 
    /// Adjusts the player's health and position accordingly. 
    /// Initiates crawling for stronger triangles if the player is equipped with a sword.
    /// </summary>
    /// <param name="collision">Collider2D object representing the collision.</param>
    void OnTriggerStay2D(Collider2D collision)
    {
        bool isEquippedSwordActive = equippedSword.activeSelf;
        bool isSwordCooldown = swordCooldown;

        if (!isEquippedSwordActive || (isEquippedSwordActive && isSwordCooldown))
        {
            if ((collision.CompareTag("Triangle") || collision.CompareTag("StrongerTriangle")) && canCollide)
            {
                if (collision.CompareTag("Triangle"))
                {
                    float newHealth = Mathf.Max(health - healthChange, 0f);
                    health = newHealth;
                    UpdateText(false);
                    UpdatePlaceholderPosition();
                }
                else if (collision.CompareTag("StrongerTriangle"))
                {
                    health = 0f;
                    UpdateText(false);
                }
            }
        }
        else if (collision.CompareTag("StrongerTriangle") && canCollide && !isSwordCooldown)
        {
            ActivateCrawlingForStrongerTriangles();
            showText.Show();
            RotateObjectTowardsTriangle(collision);
            StartCoroutine(WaitBeforeSwordCooldown());
        }
    }

    /// <summary>
    /// Updates the position of the placeholder object to match the player's position.
    /// </summary>
    private void UpdatePlaceholderPosition()
    {
        Vector3 placeholderPos = transform.position;
        placeholderPos.z = -0.1f;
        placeholder.position = placeholderPos;
    }

    /// <summary>
    /// Activates crawling for all StrongerTriangle objects and sets hitStrongerTriangle to true.
    /// </summary>
    private void ActivateCrawlingForStrongerTriangles()
    {
        Crawl[] crawlScripts = FindObjectsOfType<Crawl>();
        foreach (Crawl script in crawlScripts)
        {
            script.hitStrongerTriangle = true;
        }
    }

    /// <summary>
    /// Rotates the player's child object towards the collided triangle.
    /// </summary>
    /// <param name="triangleCollider">Collider2D object representing the collided triangle.</param>
    private void RotateObjectTowardsTriangle(Collider2D triangleCollider)
    {
        GameObject childObject = transform.GetChild(0).gameObject;
        Vector3 direction = triangleCollider.transform.position - childObject.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle += 180;
        childObject.transform.rotation = Quaternion.Euler(0, 0, angle);
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
