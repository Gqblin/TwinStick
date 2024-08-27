using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SecondEnemy : Enemies
{
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

        Vector3 playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        Vector3 direction = (playerPosition - transform.position).normalized;

        GameObject tempBullet = Instantiate(enemyBullet, transform.position, transform.rotation) as GameObject;
        Rigidbody tempRigidBodyBullet = tempBullet.GetComponent<Rigidbody>();
        tempRigidBodyBullet.AddForce(direction * enemyBulletSpeed);
        Destroy(tempBullet, 2f);
    }
}
