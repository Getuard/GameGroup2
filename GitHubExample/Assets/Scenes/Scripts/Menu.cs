using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Add me!!
public class Menu : MonoBehaviour
{

    private void Update()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void OnPlayButton()
    {
        string currentSceneName = null;
        currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Level 1");//refers to what is in build settings
        if (currentSceneName == "Menu")
        {
            SceneManager.LoadScene("Level 1");
        }
    }

        public void onSettingsButton()
    {
        // accessibilty, aim to link with inverting camera
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
}