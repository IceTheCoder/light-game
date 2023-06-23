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
    /// this method calls the LoadSceneByString() coroutine.
    /// </summary>
    /// <param name="scene">The text of the button.</param>
    public void OnSpecialButtonClick(string scene)
    {
        StartCoroutine(LoadSceneByString(scene));
    }

    /// <summary>
    /// Called when a 'level' (with an integer as text) button is clicked,
    /// this method calls the LoadCorrectScene() coroutine.
    /// </summary>
    public void OnLevelButtonClick()
    {
        StartCoroutine(LoadCorrectScene());
    }
    
    /// <summary>
    /// Called when a 'level' button is clicked by the OnLevelButtonClick() method, 
    /// this coroutine sets the button's animation to pressed, waits for the animation's length, 
    /// and loads the correct scene. This is done to prevent cases where the next scene is loaded before the animation.
    /// </summary>
    /// <returns></returns>
    IEnumerator LoadCorrectScene()
    {
        animator.SetTrigger("Pressed");

        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        int sceneIndex;
        if (int.TryParse(buttonText, out sceneIndex))
        {
            SceneManager.LoadScene(sceneIndex + 2);
        }
        else
        {
            Debug.LogError("Invalid scene index: " + buttonText);
        }
    }

    /// <summary>
    /// Called when a 'special' button is clicked, by the OnSpecialButtonClick() method, 
    /// this coroutine sets the button's animation to pressed, waits for the animation's length, 
    /// and loads the correct scene. This is done to prevent cases where the next scene is loaded before the animation.
    /// </summary>
    /// <param name="scene"></param>
    /// <returns></returns>
    IEnumerator LoadSceneByString(string scene)
    {
        animator.SetTrigger("Pressed");

        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        SceneManager.LoadScene(scene);
    }
}
