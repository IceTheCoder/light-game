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

    private void Start()
    {
        buttonText = buttonTextObject.text;
        animator = GetComponent<Animator>();
        button = GetComponent<Button>();
    }
    public void OnSpecialButtonClick(string scene)
    {
        StartCoroutine(LoadSceneByString(scene));
    }

    public void OnLevelButtonClick()
    {
        StartCoroutine(LoadCorrectScene());
    }
         
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
    IEnumerator LoadSceneByString(string scene)
    {
        animator.SetTrigger("Pressed");

        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        SceneManager.LoadScene(scene);
    }
}
