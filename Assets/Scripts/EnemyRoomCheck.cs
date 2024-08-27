using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoomCheck : MonoBehaviour
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
