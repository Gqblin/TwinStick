using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HenkDetection : MonoBehaviour
{
    HenkScript henk;

    private void Start()
    {
        henk = FindObjectOfType<HenkScript>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            henk.activated = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            henk.activated = false;
        }
    }
}
