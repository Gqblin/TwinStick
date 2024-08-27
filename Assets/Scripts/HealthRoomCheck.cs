using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRoomCheck : MonoBehaviour
{
    public bool playerEntered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerEntered = true;
        }
    }
}
