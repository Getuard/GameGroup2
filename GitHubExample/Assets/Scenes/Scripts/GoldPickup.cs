using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickup : MonoBehaviour
{
    public int value;
    public GameObject pickupEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager gameManager = FindObjectOfType<GameManager>();

            // Check if this is the large red coin
            if (gameObject.CompareTag("RedCoin"))
            {
                gameManager.CollectLargeRedCoin();
                // Add effect and/or sound for collecting the large red coin
                // Maybe instantiate a special effect or play a sound
            }
            else // This is a regular gold coin
            {
                gameManager.addGold(value);
                Instantiate(pickupEffect, transform.position, transform.rotation);
            }

            Destroy(gameObject);
        }
    }
}

