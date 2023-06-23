using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadNextScene : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Animator animator;

    /// <summary>
    /// Called when the script is first loaded, this method gets the Animator and Button components.
    /// </summary>
    private void Start()
    {
        animator = GetComponent<Animator>();
        button = GetComponent<Button>();
    }

    /// <summary>
    /// Called when a button is clicked, this method starts the LoadTheNextScene() coroutine.
    /// </summary>
    public void OnButtonClick()
    {
        StartCoroutine(LoadTheNextScene());
    }

    /// <summary>
    /// Called after a button is clicked by the OnButtonClick() method, 
    /// this coroutine sets the button's animation to 'Pressed',
    /// and waits for the length of the animation before loading the next scene.
    /// This is done to prevent cases where the user would click a button, 
    /// but the next scene would load before the animation.
    /// </summary>
    /// <returns>Nothing.</returns>
    IEnumerator LoadTheNextScene()
    {
        animator.SetTrigger("Pressed");

        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
