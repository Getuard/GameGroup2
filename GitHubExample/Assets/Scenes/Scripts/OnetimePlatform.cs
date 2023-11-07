using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnetimePlatform : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        Destroy(gameObject);//destroys the platform
    }
}
