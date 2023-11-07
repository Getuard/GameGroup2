
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.UI;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public int currentGold;
    public TextMeshProUGUI goldText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string currentSceneName = null;
        currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == "Level 1")
        {
            if (currentGold == 4)
            {
                SceneManager.LoadScene("Level 2");
            }
        }
        else if (currentSceneName == "Level 2")
        {
            if (currentGold == 10)
            {
                SceneManager.LoadScene("Congratulations");
            }
        }
    }
    public void addGold(int goldToAdd)
    {
        currentGold += goldToAdd;
        goldText.text = "Gold: " + currentGold;
    }
}
