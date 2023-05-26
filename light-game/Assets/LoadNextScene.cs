using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadNextScene : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        button = GetComponent<Button>();
    }
    public void OnButtonClick()
    {
        StartCoroutine(LoadTheNextScene());
    }
    IEnumerator LoadTheNextScene()
    {
        animator.SetTrigger("Pressed");

        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
