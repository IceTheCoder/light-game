using UnityEngine;
using TMPro;
using System.Collections;
using System.Text;
using UnityEngine.SceneManagement;

public class TypewriterEffect : MonoBehaviour
{
    public float typingSpeed = 0.1f;  // Delay between each letter
    public float deletionSpeed = 0.05f;  // Delay between each letter during deletion
    public float delayBeforeDeletion = 2f;  // Delay before text starts disappearing
    public string[] texts;

    private TextMeshProUGUI textMeshPro;
    private StringBuilder currentText;
    private Coroutine typingCoroutine;
    private Coroutine deletionCoroutine;
    private int textIndex = 0;

    private void OnEnable()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        currentText = new StringBuilder();

        typingCoroutine = StartCoroutine(TypeText());
    }

    private IEnumerator TypeText()
    {
        yield return new WaitForSeconds(delayBeforeDeletion);

        if (textIndex < texts.Length)
        {
            string fullText = texts[textIndex];

            for (int i = 0; i < fullText.Length; i++)
            {
                currentText.Append(fullText[i]);
                textMeshPro.text = currentText.ToString();

                yield return new WaitForSeconds(typingSpeed);
            }

            deletionCoroutine = StartCoroutine(DeleteText());
        }
    }

    private IEnumerator DeleteText()
    {
        yield return new WaitForSeconds(delayBeforeDeletion);

        for (int i = currentText.Length - 1; i >= 0; i--)
        {
            currentText.Remove(i, 1);
            textMeshPro.text = currentText.ToString();

            yield return new WaitForSeconds(deletionSpeed);
        }

        textIndex++;

        if (textIndex < texts.Length)
        {
            typingCoroutine = StartCoroutine(TypeText());
        }
        else
        {
            if (texts.Length == 1)
            {
                yield return new WaitForSeconds(0.5f);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    private void OnDestroy()
    {
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        if (deletionCoroutine != null)
            StopCoroutine(deletionCoroutine);
    }
    private void OnDisable()
    {
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        if (deletionCoroutine != null)
            StopCoroutine(deletionCoroutine);
    }

}
