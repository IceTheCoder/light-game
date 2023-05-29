using UnityEngine;

public class OpenLicenseLink : MonoBehaviour
{
    private string licenseURL = "https://github.com/IceTheDev2/light-game/blob/main/LICENSE";

    public void OpenLink()
    {
        Application.OpenURL(licenseURL);
    }
}
