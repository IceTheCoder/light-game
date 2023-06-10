using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class TriangleCollision : MonoBehaviour
{
    public float health; 
    public float healthChange;
    public float collisionDelay = 1f;
    public float minHealth = 0.1f;
    bool dead;
    bool canCollide = false;
    public TextMeshProUGUI textBox;
    public GameObject gameOverPanel;
    private UnityEngine.Rendering.Universal.Light2D theLight;

    /// <summary>
    /// Called when the script first runs, this method sets dead to false, health to 1 and starts
    /// the CollisionDelay coroutine.
    /// </summary>
    void Start() {
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
    /// </summary>
    /// <param name="collision"></param>
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Triangle") && canCollide)
        {
            float[] health0 = new float[] {health - healthChange, 0f};
            health = health0.Max();
            UpdateText(false);
        }
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

    IEnumerator ColorChange(bool heal) {
        if (heal == true)
        {
            textBox.color = Color.blue;
        } else
        {
            textBox.color = Color.red;
        }
        yield return new WaitForSeconds(1f);
        textBox.color = Color.white;
    }
}
