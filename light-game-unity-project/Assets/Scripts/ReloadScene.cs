using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    /// <summary>
    /// Called when the player's health reaches 0, this function reloads the active scene.
    /// </summary>
    public void LoadSameScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
