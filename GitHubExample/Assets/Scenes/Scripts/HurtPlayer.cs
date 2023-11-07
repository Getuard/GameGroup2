using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    public int damageToGive = 1;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") //create tag in inspector
        {
            Vector3 hitDirection = other.transform.position - transform.position;
            hitDirection = hitDirection.normalized;
            FindObjectOfType<HealthManager>().hurtPlayer(damageToGive,hitDirection);
        }
    }
}
