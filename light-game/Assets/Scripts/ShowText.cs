// This script should be used for the sword cooldown, so the length of the sword cooldown can be changed within TriangleCollision.
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowText : MonoBehaviour
{
    private RectTransform rectTransform;
    public LightCalculator lightCalculator;

    /// <summary>
    /// Called when the script first loads, this method gets the RectTransform component of the object it sits on.
    /// </summary>
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    /// <summary>
    /// Called when a piece of text (such as '+1 SWORD' or the sword cooldown warning) needs to be shown, 
    /// this method sets the position of that text to be visible to the user.
    /// </summary>
    public void Show()
    {
        if (lightCalculator.won == false) 
        {
            rectTransform.anchoredPosition = new Vector2(0, 450f);
        }
    }

    /// <summary>
    /// Called when a piece of text (such as '+1 SWORD' or the sword cooldown warning) needs to be hidden, 
    /// this method sets the position of that text to be invisible to the user.
    /// </summary>
    public void Hide()
    {
        if (lightCalculator.won == false)
        {
            rectTransform.anchoredPosition = new Vector2(0, 1000f);
        }
    }
}
