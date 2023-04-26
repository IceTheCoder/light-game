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
    public TextMeshProUGUI textMeshProUGUI;
    bool dead;
    public GameObject gameOverPanel;
    bool canCollide = false;

    /// <summary>
    /// Called when the script first runs, this method sets dead to false, health to 1 and starts
    /// the CollisionDelay coroutine.
    /// </summary>
    void Start() {
        dead = false;
        health = 1f;
        StartCoroutine(CollisionDelay());
    }

    /// <summary>
    /// Called once per frame, this method constantly checks if the health reached 0, and uses the
    /// dead bool to activate the gameOverPanel only once. It also sets the health to 0 if it's below
    /// 0.01.
    /// </summary>
    private void Update()
    {
        if (health == 0)
        {
            if (!dead)
            {
                gameOverPanel.SetActive(true);
            }
            dead = true;
        }
        if (health < 0.01f)
        {
            health = 0f;
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
    /// Called once per frame if touching the triangle and canCollide is true, this method changes the
    /// health to 0 or to health - healthChange (so the health decreases when colliding with a triangle
    /// and it can't go below 0) and updates the text box displaying the health value accordingly.
    /// </summary>
    /// <param name="collision"></param>
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Triangle" && canCollide)
        {
            float[] health0 = new float[] {health - healthChange, 0f};
            health = health0.Max();
            textMeshProUGUI.text = "Health: " + (health * 10).ToString("0");
        }
    }
}
