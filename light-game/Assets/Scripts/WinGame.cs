using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    public GameObject winGamePanel;
    public LightCalculator lightCalculator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WinCondition"))
        {
            winGamePanel.SetActive(true);
            lightCalculator.won = true;
        }
    }
}
