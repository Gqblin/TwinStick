using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] private float healingAmount = 50f;
    PlayerHealth playerHealth;

    private float pickUpDistance = 1.5f;
    public bool healthPickedUp;

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
                if(playerHealth.ReturnCurrentHealth() < playerHealth.ReturnMaxHealth())
                {
                    healthPickedUp = true;
                    playerHealth.ChangeHealth(healingAmount);
                    Destroy(gameObject);
                } 
            }
        }
    }
}
