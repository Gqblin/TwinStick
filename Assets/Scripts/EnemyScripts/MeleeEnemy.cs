using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemies
{
    [Header("Attack settings")]
    [SerializeField] private float timeBetweenAttacks = 0.8f;
    [SerializeField] private float activeWeaponTime = 0.2f;
    [SerializeField] private GameObject weapon;

    private bool closeEnough = false;
    private bool attackedPlayer = false;

    protected override void CheckDistance()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance >= minDistanceFromPlayer)
        {
            agent.SetDestination(player.transform.position);
            closeEnough = false;
        }
        else if (distance < minDistanceFromPlayer)
        {
            agent.SetDestination(transform.position);
            TurnToPlayer();
            closeEnough = true;
        }

        if (closeEnough && attackedPlayer == false)
        {
            StartCoroutine("AttackPlayer");
            attackedPlayer = true;
        }
    }

    private IEnumerator AttackPlayer()
    {
        weapon.SetActive(true);

        yield return new WaitForSeconds(activeWeaponTime);

        weapon.SetActive(false);

        yield return new WaitForSeconds(timeBetweenAttacks);
        attackedPlayer = false;
    }
}
