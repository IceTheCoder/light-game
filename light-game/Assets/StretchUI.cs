using UnityEngine;

public class StretchUI : MonoBehaviour
{

    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();

        // Position the UI object to sit at the top of the screen
        rectTransform.anchorMin = new Vector2(0.5f, 1f);
        rectTransform.anchorMax = new Vector2(0.5f, 1f);
        rectTransform.pivot = new Vector2(0.5f, 0.5f);
        // rectTransform.anchoredPosition = new Vector2(0f, 0f);
    }
}
