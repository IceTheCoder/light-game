// This script should be used for the '+1 Sword' text.
using System.Collections;
using UnityEngine;
using TMPro;

public class Show1SwordText : MonoBehaviour
{
    public float secondsOfText = 0.5f;
    private RectTransform rectTransform;

    /// <summary>
    /// Called when the script is first loaded, this method gets the RectTransform component of the object it sits on.
    /// </summary>
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    /// <summary>
    /// Called when the '+1 SWORD' text needs to be shown, this function moves its y position so it's visible and starts the UpdatePositionAfterDelay() coroutine.
    /// </summary>
    public void Show()
    {
        rectTransform.anchoredPosition = new Vector2(0, 450f);
        StartCoroutine(UpdatePositionAfterDelay());
    }

    /// <summary>
    /// Called when the '+1 SWORD' text needs to be shown by the Show() method, this coroutine waits secondsOfText seconds before hiding the text.
    /// </summary>
    /// <returns></returns>
    IEnumerator UpdatePositionAfterDelay()
    {
        yield return new WaitForSeconds(secondsOfText);
        rectTransform.anchoredPosition = new Vector2(0, 1000f);
    }
}
