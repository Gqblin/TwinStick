using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorPickUp : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] private float shieldAmount = 100f;
    PlayerHealth playerHealth;

    private float pickUpDistance = 1.5f;

    void Start()
    {
        player = FindObjectOfType<Player>();
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance < pickUpDistance)
        {
            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.F))
            {
                if(playerHealth.ReturnCurrentShield() < playerHealth.ReturnMaxShield())
                {
                    playerHealth.ChangeShield(shieldAmount);
                    Destroy(gameObject);
                }
            }
        }
    }
}
