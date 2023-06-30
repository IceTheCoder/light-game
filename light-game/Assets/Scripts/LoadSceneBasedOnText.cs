using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro.Examples;
using TMPro;
using UnityEngine.Rendering;

public class LoadSceneBasedOnText : MonoBehaviour
{
    public TextMeshProUGUI buttonTextObject;
    private string buttonText;
    [SerializeField] private Button button;
    [SerializeField] private Animator animator;

    /// <summary>
    /// Called when the script is first loaded, this method gets the buttonText, animator, and button components.
    /// </summary>
    private void Start()
    {
        buttonText = buttonTextObject.text;
        animator = GetComponent<Animator>();
        button = GetComponent<Button>();
    }

    /// <summary>
    /// Called when a 'special' (with text other than integers) button is clicked,
    /// this method loads the correct scene.
    /// </summary>
    /// <param name="scene">The text of the button.</param>
    public void OnSpecialButtonClick(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    /// <summary>
    /// Called when a 'level' (with an integer as text) button is clicked,
    /// this method loads the correct scene.
    /// </summary>
    public void OnLevelButtonClick()
    {
        int sceneIndex;
        if (int.TryParse(buttonText, out sceneIndex))
        {
            SceneManager.LoadScene(sceneIndex + 2); // There are 2 scenes before the levels start.
        }
        else
        {
            Debug.LogError("Invalid scene index: " + buttonText);
        }
    }
}
