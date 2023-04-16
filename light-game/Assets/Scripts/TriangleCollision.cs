using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class TriangleCollision : MonoBehaviour
{
    public float health; 
    public float healthChange;
    public float collisionDelay = 0.67f;
    public TextMeshProUGUI textMeshProUGUI;
    bool dead;
    public GameObject gameOverPanel;
    bool canCollide = false;


    void Start() {
        dead = false;
        health = 1f;
        StartCoroutine(CollisionDelay());
    }

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

    IEnumerator CollisionDelay()
    {
        yield return new WaitForSeconds(collisionDelay);
        canCollide = true;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Triangle" && canCollide)
        {
            float[] health0 = new float[] {health - healthChange, 0f};
            health = health0.Max();
            textMeshProUGUI.text = "Health: " + (health * 100).ToString("0");
        }
    }
}
