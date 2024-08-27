using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealerWand : Wand
{
    [SerializeField] private float healSpeed;
    [SerializeField] private ParticleSystem particleSystem;
    //private PlayerHealth playerHealth;

    private void Start()
    {
        //playerHealth = FindObjectOfType<PlayerHealth>();
    }

    public override void CastSpecialSpell()
    {
        if(playerHealth.ReturnCurrentHealth() < playerHealth.ReturnMaxHealth())
        {
            //Instantiate(specialSpellObject, transform.position, transform.rotation);
            playerHealth.ChangeHealth(healSpeed * Time.deltaTime);
            playerHealth.ChangeMana(-specialSpellCost * Time.deltaTime);
        }
        
    }

    public override float ReturnSpecialSpellCost()
    {
        return specialSpellCost * Time.deltaTime;
    }
}
