using System.Collections;
using TMPro;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    public GameObject winGamePanel;
    public LightCalculator lightCalculator;
    public TriangleCollision triangleCollision;
    public GameObject healthText;
    private float winDelay = 2f;
    private bool canCollide = false;
    public GameObject voiceObject;
    public GameObject voiceObject2;
    private TypewriterEffect typewriterEffect;
    public TextMeshProUGUI voiceTextMeshPro;
    public string winVoiceText;

    /// <summary>
    /// Called when the script first loads,
    /// this fucntions sets canCollide to false,
    /// waits for the WinDelay to pass,
    /// and gets the TypewriterEffect script.
    /// </summary>
    private void Start()
    {
        canCollide = false;
        StartCoroutine(WinDelay());
        if (voiceObject != null)
        {
            typewriterEffect = voiceObject.GetComponent<TypewriterEffect>();
        }
    }

    /// <summary>
    /// This coroutine waits for the winDelay amount of seconds to pass before setting canCollide to true.
    /// </summary>
    /// <returns>Nothing.</returns>
    private IEnumerator WinDelay()
    {
        yield return new WaitForSeconds(winDelay);
        canCollide = true;
    }

    /// <summary>
    /// Called when the object collides with another trigger object,
    /// this method checks if the object is a WinCondition and then
    /// disables triangle collision (if necessary), health, activates the WinGame panel (if necessary),
    /// sets the won variable of lightCalculator to true (to make the light slowly increase in radius),
    /// and deactivates the first voice and activates the 2nd one (to tell the user to watch out for enemies),
    /// and sets the text to black.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WinCondition") && canCollide)
        {
            canCollide = false;
            if (triangleCollision != null)
            {
                triangleCollision.enabled = false;
            }
            if (healthText != null)
            {
                healthText.SetActive(false);
            }
            if (winGamePanel != null)
            {
                winGamePanel.SetActive(true);
            }
            if (lightCalculator != null)
            {
                lightCalculator.won = true;
            }
            if (typewriterEffect != null && voiceObject != null && voiceObject2 != null && voiceTextMeshPro != null)
            {
                voiceObject.SetActive(false);
                voiceObject2.SetActive(true);
                voiceTextMeshPro.color = Color.black;
            }
        }
    }
}
