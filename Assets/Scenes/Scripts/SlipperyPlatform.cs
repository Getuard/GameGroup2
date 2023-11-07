using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slippery : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
    }
}
