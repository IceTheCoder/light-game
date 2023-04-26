using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    public GameObject winGamePanel;
    public LightCalculator lightCalculator;
    public TriangleCollision triangleCollision;
    public GameObject healthText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WinCondition"))
        {
            triangleCollision.enabled = false;
            healthText.SetActive(false);
            winGamePanel.SetActive(true);
            lightCalculator.won = true;
        }
    }
}
