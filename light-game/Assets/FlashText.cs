using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlashText : MonoBehaviour
{
    private RectTransform rectTransform;
    public float flashInterval = 0.05f; // Time the flash is not shown
    private float timeSinceLastFlash = 0f;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        timeSinceLastFlash += Time.deltaTime;
        if (timeSinceLastFlash >= flashInterval)
        {
            StartCoroutine(Flash());
            timeSinceLastFlash = 0f;
        }
    }

    IEnumerator Flash()
    {
        rectTransform.anchoredPosition = new Vector2(0, 450f);
        yield return new WaitForSeconds(0.1f); // Time the flash is shown
        rectTransform.anchoredPosition = new Vector2(0, 1000f);
    }
}
