using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button button = GetComponent<Button>();

        // Add an event listener to the button
        button.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
     private void QuitGame()
    {
        // Quit the game (works in standalone builds and the editor)
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
