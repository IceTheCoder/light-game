using UnityEngine;

public class DisableText : MonoBehaviour
{
    private void Start()
    {
        if (AttributionManager.textShown)
        {
            gameObject.SetActive(false);
        }
        else
        {
            AttributionManager.textShown = true;
        }
    }
}
