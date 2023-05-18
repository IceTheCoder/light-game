using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    public GameObject winGamePanel;
    public LightCalculator lightCalculator;
    public TriangleCollision triangleCollision;
    public GameObject healthText;
    private float winDelay = 2f;
    private bool canCollide = false;
    public GameObject voiceObject;
    private TypewriterEffect typewriterEffect;
    public string winVoiceText;

    /// <summary>
    /// Called when the script first loads, this function sets canCollide to false
    /// and starts the WinDelay() Coroutine.
    /// </summary>
    private void Start()
    {
        canCollide = false;
        StartCoroutine(WinDelay());
        if (voiceObject != null)
        {
            typewriterEffect = voiceObject.GetComponent<TypewriterEffect>();
        }
    }

    /// <summary>
    /// Callled shortly after the script loads, this coroutine waits for winDelay seconds before
    /// setting canCollide to true.
    /// </summary>
    /// <returns></returns>
    private IEnumerator WinDelay()
    {
        yield return new WaitForSeconds(winDelay);
        canCollide = true;
    }

    /// <summary>
    /// Called when the object collides, this method check if it collides with a WinCondition and 
    /// if it canCollide, then sets canCollide to false, disables triangle collision, health text,
    /// activates the WinGamePanel and sets the won variable of lightCalculator to true.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WinCondition") && canCollide)
        {
            canCollide = false;
            if (triangleCollision != null)
            {
                triangleCollision.enabled = false;
            }
            if (healthText != null)
            {
                healthText.SetActive(false);
            }
            if (winGamePanel != null) 
            {
                winGamePanel.SetActive(true);
            }
            if (lightCalculator != null)
            {
                lightCalculator.won = true;
            }
            if (typewriterEffect != null && voiceObject != null)
            {
                voiceObject.SetActive(false);
                typewriterEffect.texts = new string[] { winVoiceText };
                voiceObject.SetActive(true);
            }
        }
    }
}
