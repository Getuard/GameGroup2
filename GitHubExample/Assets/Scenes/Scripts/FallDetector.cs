using UnityEngine;
using UnityEngine.SceneManagement;

public class FallDetector : MonoBehaviour
{
    private float fallThreshold = -6.0f; // Set this to whatever y-value is considered "fallen off"

    void Update()
    {
        // Check if the player has fallen below the threshold
        if (transform.position.y < fallThreshold)
        {
            OnPlayerFall();
        }
    }

    private void OnPlayerFall()
    {
        Debug.Log("You Lose! Player has fallen off the platform.");
        // Optionally, you could add a delay here using a coroutine to wait before reloading the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

