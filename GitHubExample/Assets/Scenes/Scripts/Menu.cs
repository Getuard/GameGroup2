using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Add me!!
public class Menu : MonoBehaviour
{


    public void OnPlayButton()
    {
        SceneManager.LoadScene("final 3 enemies ");
    }

    public void onSettingsButton()
    {
        // SceneManager.LoadScene("settings");
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }

}