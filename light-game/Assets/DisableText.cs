using UnityEngine;

public class DisableText : MonoBehaviour
{
    private void Start()
    {
        if (AttributionManager.textShown)
        {
            Debug.Log("Text already shown. Disabling...");
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Text not shown before. Enabling...");
            AttributionManager.textShown = true;
        }
    }
}
