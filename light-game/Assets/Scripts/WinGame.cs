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
    private TypewriterEffect typewriterEffect;
    public TextMeshProUGUI voiceTextMeshPro;
    public string winVoiceText;

    private void Start()
    {
        canCollide = false;
        StartCoroutine(WinDelay());
        if (voiceObject != null)
        {
            typewriterEffect = voiceObject.GetComponent<TypewriterEffect>();
        }
    }

    private IEnumerator WinDelay()
    {
        yield return new WaitForSeconds(winDelay);
        canCollide = true;
    }

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
            if (typewriterEffect != null && voiceObject != null && voiceTextMeshPro != null)
            {
                voiceObject.SetActive(false);
                typewriterEffect.texts = new string[] { winVoiceText };
                voiceObject.SetActive(true);
                voiceTextMeshPro.color = Color.black;
            }
        }
    }
}
