using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public string nextSceneName = "UI"; // Name of the next scene to load

    private void Start()
    {
        // Find the button component attached to the same GameObject
        Button button = GetComponent<Button>();

        // Add an event listener to the button
        button.onClick.AddListener(LoadNextScene);
    }

    private void LoadNextScene()
    {
        // Load the next scene
        SceneManager.LoadScene(nextSceneName);
    }
}