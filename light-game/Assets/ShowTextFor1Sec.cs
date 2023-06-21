using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using UnityEngine;

public class ShowTextFor1Sec : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float seconds = 1f;


    public void Show()
    {
        Debug.Log("Showing text...");
        text.enabled = true;
        StartCoroutine(Disable());
    }

    IEnumerator Disable()
    {
        yield return new WaitForSeconds(seconds);
        text.enabled = false;
    }
}
