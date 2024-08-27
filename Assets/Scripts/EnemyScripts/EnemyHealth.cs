using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemyHealth : Health
{
    public RectTransform healthBar;
    public RectTransform shieldBar;
    [SerializeField] private AudioClip deathScream;
    [SerializeField] private float xpOnDeath = 25f;
    //[SerializeField] private AudioClip hitScream;
    private PlayerLevel playerLevel;
    void Start()
    {
        health = maxHealth;
        shield = maxShield;
        playerLevel = FindObjectOfType<PlayerLevel>();
    }

    public override void ChangeHealth(float healthAmount)
    {
        //AudioSource.PlayClipAtPoint(hitScream, transform.position);
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
        healthBar.sizeDelta = new Vector2(health / maxHealth * 200, healthBar.sizeDelta.y);
        shieldBar.sizeDelta = new Vector2(shield / maxShield * 200, shieldBar.sizeDelta.y);
    }

    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
        
    }

    public override void Die()
    {
        //WinGame winGame = GetComponent<WinGame>();
        //winGame.ChangeArray(this.gameObject);
        Destroy(this.gameObject);
        playerLevel.ReciveExp(xpOnDeath);
        AudioSource.PlayClipAtPoint(deathScream, transform.position);
    }
}
