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
    /// Called when a button is clicked, this method loads the next scene.
    /// </summary>
    public void OnButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
