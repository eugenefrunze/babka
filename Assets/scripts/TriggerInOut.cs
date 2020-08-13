using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInOut : MonoBehaviour
{
    public bool isPlayerIn;

    private void OnTriggerEnter(Collider other)
    {
        isPlayerIn = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isPlayerIn = false;
    }
}
