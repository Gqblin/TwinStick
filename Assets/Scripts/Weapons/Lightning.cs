using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    [SerializeField] private float damage = 100;
    Wand wand;

    private void Start()
    {
        wand = FindObjectOfType<Wand>();
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.ChangeHealth(-damage * wand.damageMultiplier);
            EnemyFOV enemyfov;
            enemyfov = other.GetComponent<EnemyFOV>();
            enemyfov.attackedByPlayer = true;
        }
    }
}
