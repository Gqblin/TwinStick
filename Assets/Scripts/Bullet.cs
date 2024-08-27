using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected float damage;
    protected float speed;
    protected float range;
    [SerializeField] protected ParticleSystem explosionParicles;

    protected virtual void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            ParticleSystem particle = Instantiate(explosionParicles, transform.position, transform.rotation);
            //explosionParicles.Play();
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.ChangeHealth(-damage);
        }
        if(collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
            Instantiate(explosionParicles, transform.position, transform.rotation);
            //explosionParicles.Play();
        }
    }

    public void SetBulletStats(float dmg, float spd)
    {
        damage = dmg;
        speed = spd;
    }
}
