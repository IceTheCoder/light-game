// This script should be used for the '+1 Sword' text.
using System.Collections;
using UnityEngine;
using TMPro;

public class Show1SwordText : MonoBehaviour
{
    public float seconds = 0.5f;
    private RectTransform rectTransform;

    /// <summary>
    /// 
    /// </summary>
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void Show()
    {
        rectTransform.anchoredPosition = new Vector2(0, 450f);
        StartCoroutine(UpdatePositionAfterDelay());
    }

    IEnumerator UpdatePositionAfterDelay()
    {
        yield return new WaitForSeconds(seconds);
        rectTransform.anchoredPosition = new Vector2(0, 1000f);
    }
}
