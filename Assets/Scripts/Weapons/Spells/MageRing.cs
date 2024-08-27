using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageRing : Bullet
{
    [SerializeField] private float duration = 6;

    private void Update()
    {
        duration -= Time.deltaTime;
        if(duration <= 0)
        {
            Destroy(gameObject);
        }
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        //nothing
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.ChangeHealth(-damage * Time.deltaTime);
        }
    }

}
