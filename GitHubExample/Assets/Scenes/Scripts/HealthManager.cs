using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth;
    public int currentHealth;

    public PlayerController thePlayer;

    public float invincibiltyLength;
    private float invincibiltyCounter;

    public Renderer playerRenderer;
    private float flashCounter;

    public float flashLength = 0.1f;

    private Vector3 respawnPoint;

    public float respawnLength;
    private bool isRespawning;

    void Start()
    {
        currentHealth = maxHealth;

        //thePlayer = FindObjectOfType<PlayerController>();

        respawnPoint = thePlayer.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if(invincibiltyCounter > 0)
        {
            invincibiltyCounter -= Time.deltaTime;

            flashCounter -= Time.deltaTime;
            if(flashCounter <= 0)
            {
                playerRenderer.enabled = !playerRenderer.enabled;
                flashCounter =flashLength;
            }

            if(invincibiltyCounter<=0)
            {
                playerRenderer.enabled=true;
            }
        }
    }
    public void hurtPlayer(int damage, Vector3 direction)
    {
        if(invincibiltyCounter <= 0)
        {
            currentHealth -= damage;

            if(currentHealth<=0){
                Respawn();
            }else{

                thePlayer.Knockback(direction);

                invincibiltyCounter = invincibiltyLength;

                playerRenderer.enabled = false;
                flashCounter = flashLength;

            }
        }
    }

    public void Respawn()
    {
        // Disable the character controller
        CharacterController charController = thePlayer.GetComponent<CharacterController>();
        if (charController != null) // Make sure the CharacterController is present
        {
            charController.enabled = false;
        }

        // Move the player to the respawn point
        thePlayer.transform.position = respawnPoint;

        // Re-enable the character controller
        if (charController != null)
        {
            charController.enabled = true;
        }

        // Reset health
        currentHealth = maxHealth;

        // Reset any other necessary states here (e.g., invincibility, player visibility)
        invincibiltyCounter = 0;
        playerRenderer.enabled = true;

        // if(!isRespawning){
        //     StartCoroutine("RespawnCo");

        // }
        if (isRespawning)
        {
            // If already respawning, stop the current coroutine
            StopCoroutine("RespawnCo");
        }
    
        StartCoroutine("RespawnCo");
    }

    public IEnumerator RespawnCo()
    {
        isRespawning = true;
        thePlayer.gameObject.SetActive(false);

        // Reset health and other necessary states here if needed before the wait
        currentHealth = maxHealth;
        playerRenderer.enabled = false;
        invincibiltyCounter = invincibiltyLength;

        yield return new WaitForSeconds(respawnLength);

        thePlayer.gameObject.SetActive(true);
        thePlayer.transform.position = respawnPoint;

        // Ensure the invincibility and flashing logic is reset and ready to run again
        flashCounter = flashLength;
        
        // Wait for the invincibility length before turning off invincibility
        yield return new WaitForSeconds(invincibiltyLength);

        // Turn off invincibility and stop flashing after the invincibility period is over
        invincibiltyCounter = 0;
        playerRenderer.enabled = true;

        // Indicate that the respawning process is complete
        isRespawning = false;
    }



    public void HealPlayer(int healAmount)
    {
        currentHealth += healAmount;

        if(currentHealth > healAmount)
        {
            currentHealth = maxHealth;
        }
    }
}
