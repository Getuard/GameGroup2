using UnityEngine;
using UnityEngine.SceneManagement;

public class FallDetector : MonoBehaviour
{
    private float fallThreshold = -6.0f; // y-value that is considered "fallen off"

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

