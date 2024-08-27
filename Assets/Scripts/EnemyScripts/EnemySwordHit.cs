using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwordHit : MonoBehaviour
{
    [SerializeField] float damage = -20f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            playerHealth.ChangeHealth(damage);
        }
    }
}
