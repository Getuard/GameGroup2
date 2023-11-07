using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFallingDeath : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Death");
    }
}
