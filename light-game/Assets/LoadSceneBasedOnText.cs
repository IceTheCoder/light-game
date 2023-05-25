using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro.Examples;
using TMPro;

public class LoadSceneBasedOnText : MonoBehaviour
{
    public TextMeshProUGUI buttonTextObject;
    private string buttonText;

    private void Start()
    {
        buttonText = buttonTextObject.text;
    }

    public void LoadCorrectScene()
    {
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

    public void LoadSceneByString(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
