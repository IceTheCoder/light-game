using UnityEngine;

public class OpenLicenseLink : MonoBehaviour
{
    private string licenseURL = "https://github.com/IceTheDev2/light-game/blob/main/LICENSE";

    /// <summary>
    /// Called when the user clicks the link of the licence, this method loads that link.
    /// </summary>
    public void OpenLink()
    {
        Application.OpenURL(licenseURL);
    }
}
