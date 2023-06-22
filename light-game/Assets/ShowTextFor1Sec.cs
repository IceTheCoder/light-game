using System.Collections;
using UnityEngine;
using TMPro;

public class ShowTextFor1Sec : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI;
    public float seconds = 1f;
    public float y = 1000f;
    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = textMeshProUGUI.GetComponent<RectTransform>();
    }

    public void Show()
    {
        rectTransform.anchoredPosition = new Vector2(0, 450f);
        StartCoroutine(UpdatePositionAfterDelay());
    }

    IEnumerator UpdatePositionAfterDelay()
    {
        yield return new WaitForSeconds(0.5f);
        rectTransform.anchoredPosition = new Vector2(0, 1000f);
    }
}
