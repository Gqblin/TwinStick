using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendersWand : Wand
{
    [SerializeField] private GameObject defendersShield;
    [SerializeField] private float chargeDamageMultiplier = 1.01f;
    [SerializeField] private float maxDamage = 120;

    private PlayerHealth playerHealth;
    private float startDamage = 1;
    public float damage = 0;

    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    public override void CastBasicSpell()
    {
        if(damage < maxDamage)
        {
            damage *= chargeDamageMultiplier;
        }
        if(damage > maxDamage)
        {
            damage = maxDamage;
        }
    }

    public override void Update()
    {
        base.Update();
        //if (Input.GetButtonUp("Fire2"))
        //{
        //    defendersShield.SetActive(false);
        //    playerHealth.infiniteHealth = false;
        //}
    }

    public override void CastSpecialSpell()
    {
        if(playerHealth.RetunManaAmount() >= ReturnBasicSpellCost())
        {
            defendersShield.SetActive(true);
            playerHealth.infiniteHealth = true;
            playerHealth.ChangeMana(-specialSpellCost * Time.deltaTime);
        }

    }

    public override void LeftMouseReleased()
    {
        GameObject projectile = Instantiate(basicSpellObject, transform.position, transform.rotation);
        projectile.GetComponent<Bullet>().SetBulletStats(damage, basicSpellSpeed);
        playerHealth.ChangeMana(-damage / 2);
        damage = startDamage;
    }

    public override float ReturnSpecialSpellCost()
    {
        return specialSpellCost * Time.deltaTime;
    }

    public override void RightMouseReleased()
    {
        defendersShield.SetActive(false);
        playerHealth.infiniteHealth = false;
    }

    public override void StopSpecialSpell()
    {
        defendersShield.SetActive(false);
        playerHealth.infiniteHealth = false;
    }

}
