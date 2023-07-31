using UnityEngine;

public class DisableLicence : MonoBehaviour
{
    /// <summary>
    /// Called when the script is first loaded, this method checks, 
    /// through the Attribution Manager script, if the attributon text has already been shown.
    /// If it has been shown, it disables the text (so it's only shown once),
    /// else it lets the text be shown and sets textShown to true to prevent further appearances of the text.
    /// </summary>
    private void Start()
    {
        if (LicenceManager.textShown)
        {
            gameObject.SetActive(false);
        }
        else
        {
            LicenceManager.textShown = true;
        }
    }
}
