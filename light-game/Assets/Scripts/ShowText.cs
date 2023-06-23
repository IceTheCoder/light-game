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
    /// Called when a piece of text (such as '+1 SWORD' or the sword cooldown warning), this method sets the position of that text to be visible to the user.
    /// </summary>
    public void Show()
    {
        if (lightCalculator.won == false) 
        {
            rectTransform.anchoredPosition = new Vector2(0, 450f);
        }
    }

    public void Hide()
    {
        if (lightCalculator.won == false)
        {
            rectTransform.anchoredPosition = new Vector2(0, 1000f);
        }
    }
}
