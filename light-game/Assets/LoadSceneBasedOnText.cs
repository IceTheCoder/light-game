using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSceneBasedOnText : MonoBehaviour
{
    private Button button;
    private string buttonText;

    void Start() {
        button = GetComponent<Button>();
        buttonText = button.GetComponentInChildren<Text>().text;
    }

    public void LoadCorrectScene()
    {
        SceneManager.LoadScene(Convert.ToInt32(buttonText))
    }
}
