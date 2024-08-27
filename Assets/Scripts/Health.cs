using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected float health;
    [SerializeField] protected float shield;
    [SerializeField] protected float maxHealth = 100;
    [SerializeField] protected float maxShield = 100;

    public bool infiniteHealth = false;

    void Start()
    {
        health = maxHealth;
        shield = maxShield;
    }

    public virtual void ChangeHealth(float healthAmount)
    {
        if (shield > 0 && healthAmount < 0 && infiniteHealth != true)
        {
            shield = shield + healthAmount;
            if (shield < 0)
            {
                float damageToDo = shield;
                health = health + shield;
                shield = 0;
            }
        }
        else if (infiniteHealth != true)
        {
            health = health + healthAmount;
        }
        UpdateHealth();
    }

    public void UpdateHealth()
    {
        if (health <= 0)
        {
            health = 0;
            Die();
        }
        if(health >= maxHealth)
        {
            health = maxHealth;
        }
    }

    public void ChangeShield(float shieldAmount)
    {
        shield = shield + shieldAmount;
        UpdateShield();
    }

    public void UpdateShield()
    {
        if (shield >= maxShield)
        {
            shield = maxShield;
        }
    }

    public float ReturnCurrentHealth()
    {
        return health;
    }

    public float ReturnMaxHealth()
    {
        return maxHealth;
    }

    public float ReturnCurrentShield()
    {
        return shield;
    }

    public float ReturnMaxShield()
    {
        return maxShield;
    }


    public virtual void Die()
    {
        //Do something
    }
}
