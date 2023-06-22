using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowText : MonoBehaviour
{
    private RectTransform rectTransform;
    public LightCalculator lightCalculator;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

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
