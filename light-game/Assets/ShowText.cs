using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowText : MonoBehaviour
{
    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void Show()
    {
        rectTransform.anchoredPosition = new Vector2(0, 450f);
    }

    public void Hide()
    {
        rectTransform.anchoredPosition = new Vector2(0, 1000f);
    }
}
