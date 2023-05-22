using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public TypewriterEffect typewriterEffect;
    public TextMeshProUGUI voice2TextMeshPro;
    public TextMeshProUGUI voiceTextMeshPro;
    public bool disableFirstVoiceAfterWinning = true;

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
    /// Called when the user finds the win condition if the voice is done with the information,
    /// this method waits for half-a-second before loading the next scene.
    /// </summary>
    /// <returns>Nothing.</returns>
    public IEnumerator NextLevelAfterDelay()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
            if (voiceTextMeshPro != null)
            {
                voiceTextMeshPro.color = Color.black;
            }
            if (voice2TextMeshPro != null)
            {
                voice2TextMeshPro.color = Color.black;
            }
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
                if (typewriterEffect.voiceIsDone == true)
                {
                    StartCoroutine(NextLevelAfterDelay());
                }
            }
            if (disableFirstVoiceAfterWinning == true && voiceObject != null && voiceObject2 != null)
            {
                voiceObject.SetActive(false);
                voiceObject2.SetActive(true);
            }
        }
    }
}