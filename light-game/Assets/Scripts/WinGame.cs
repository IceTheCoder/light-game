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
    private float winDelay = 2f;
    private bool canCollide;

    private void Start()
    {
        canCollide = false;
        StartCoroutine(WinDelay());
    }
    IEnumerator WinDelay()
    {
        yield return new WaitForSeconds(winDelay);
        canCollide = true;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WinCondition") && canCollide)
        {
            canCollide = false;
            triangleCollision.enabled = false;
            healthText.SetActive(false);
            winGamePanel.SetActive(true);
            lightCalculator.won = true;
        }
    }
}
