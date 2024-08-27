using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MageEnemy : Enemies
{
    [SerializeField] private float bulletSpread = 30f;
    [SerializeField] private float distanceBuffer = 1.5f;

    protected override void CheckDistance()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance >= minDistanceFromPlayer * distanceBuffer)
        {
            agent.SetDestination(player.transform.position);
        }
        else if (distance >= minDistanceFromPlayer && distance <= minDistanceFromPlayer * distanceBuffer)
        {
            agent.SetDestination(transform.position);
            TurnToPlayer();
        }
        else if (distance < minDistanceFromPlayer)
        {
            agent.SetDestination(-player.transform.position);
            TurnToPlayer();
        }
    }

    public override void TurnToPlayer()
    {
        if (pause.paused == false)
        {
            Vector3 relativePos = player.transform.position - transform.position;
            relativePos.y = 0;

            float damping = 10;

            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);

            StartCoroutine("WaitWithShooting");
        }
    }

    private IEnumerator WaitWithShooting()
    {
        yield return new WaitForSeconds(0.5f);

        ShootAtPlayer();
    }

    private void ShootAtPlayer()
    {
        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer > 0) return;

        cooldownTimer = cooldown;

        for (int i = 0; i < 3; i++)
        {
            GameObject bullet = Instantiate(enemyBullet, transform.position, transform.rotation);
            if(i == 1)
            {
                bullet.transform.Rotate(0, -bulletSpread, 0);
            }
            if(i == 2)
            {
                bullet.transform.Rotate(0, bulletSpread, 0);
            }
        }
    }
}
