using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int currentGold;
    public TextMeshProUGUI goldText;
    public GameObject largeRedCoin; // Assign this in the inspector

    void Start()
    {
        largeRedCoin.SetActive(false); // Start with the large red coin deactivated
    }

    public void addGold(int goldToAdd)
    {
        currentGold += goldToAdd;
        goldText.text = "Gold: " + currentGold;

        // Check if we've collected 4 gold coins
        if (currentGold >= 4)
        {
            // Make the large red coin appear
            largeRedCoin.SetActive(true);
        }
    }

    public void CollectLargeRedCoin()
    {
        // Code to transition to the next level goes here
        SceneManager.LoadScene(2);
    }
}

