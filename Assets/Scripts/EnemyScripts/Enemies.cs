using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemies : MonoBehaviour
{
    [SerializeField] protected float minDistanceFromPlayer = 2f;
    [SerializeField] protected float enemyBulletSpeed = 100;
    [SerializeField] protected List<Transform> waypoints;
    [SerializeField] protected GameObject enemyBullet;
    [SerializeField] protected float targetDistance;
    [SerializeField] protected float cooldown = 2;
    [SerializeField] protected bool moveRandom;

    protected EnemyFOV enemyFieldOfView;
    protected NavMeshAgent agent;
    protected PauseGame pause;
    protected Player player;

    protected float cooldownTimer;
    protected int currentIndex;

    void Start()
    {
        enemyFieldOfView = GetComponent<EnemyFOV>();
        pause = FindObjectOfType<PauseGame>();
        agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<Player>();
        Physics.IgnoreLayerCollision(8, 9);
        SetNextTarget();
    }

    protected virtual void Update()
    {
        if (agent.remainingDistance <= targetDistance && enemyFieldOfView.enemyState == EnemyState.walking)
        {
            SetNextTarget();
        }
        else if (enemyFieldOfView.enemyState == EnemyState.following)
        {
            CheckDistance();
        }
    }

    protected virtual void SetNextTarget()
    {
        int previousIndex = currentIndex;
        if (moveRandom)
        {
            currentIndex = Random.Range(0, waypoints.Count);
            if (currentIndex == previousIndex)
            {
                currentIndex++;
            }
        }
        else
        {
            currentIndex++;
        }
        currentIndex %= waypoints.Count;

        agent.SetDestination(waypoints[currentIndex].position);
    }


    protected virtual void CheckDistance()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance >= minDistanceFromPlayer)
        {
            agent.SetDestination(player.transform.position);
        }
        else if (distance < minDistanceFromPlayer)
        {
            agent.SetDestination(transform.position);
            TurnToPlayer();
        }
    }

    virtual public void TurnToPlayer()
    {
        if (pause.paused == false)
        {
            Vector3 relativePos = player.transform.position - transform.position;
            relativePos.y = 0;

            float damping = 10;

            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
        }
    }

    private void OnDrawGizmos()
    {
        if (waypoints.Count == 0)
        {
            return;
        }

        Gizmos.color = Color.black;
        foreach (Transform waypoint in waypoints)
        {
            Gizmos.DrawSphere(waypoint.position, 0.2f);
        }

        if (!Application.isPlaying)
        {
            return;
        }

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, agent.destination);
    }

    private void OnDrawGizmosSelected()
    {
        if (waypoints.Count == 0)
        {
            return;
        }

        Gizmos.color = Color.blue;
        foreach (Transform waypoint in waypoints)
        {
            Gizmos.DrawSphere(waypoint.position, 0.35f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
            playerHealth.ChangeHealth(-7);
            enemyFieldOfView.attackedByPlayer = true;
        }

        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            enemyFieldOfView.attackedByPlayer = true;
        }
    }
}
