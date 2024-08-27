using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health
{
    [SerializeField] private GameObject healthBar;
    [SerializeField] private GameObject healthBorder;
    [SerializeField] private GameObject manaBar;
    [SerializeField] private GameObject manaBorder;
    [SerializeField] private GameObject deathScreen;

    [SerializeField] private float maxMana = 100;
    [SerializeField] private float manaRechargeSpeed = 1;
    private float timeBeforeManaRecharge = 2;
    public float mana;

    float counter;


    void Start()
    {
        health = maxHealth;
        shield = 0;
        mana = maxMana;
    }

    void Update()
    {
        healthBar.GetComponent<Image>().fillAmount = health / maxHealth;
        manaBar.GetComponent<Image>().fillAmount = mana / maxMana;

        counter += Time.deltaTime;
        if(counter >= timeBeforeManaRecharge && mana < maxMana)
        {
            mana += manaRechargeSpeed * Time.deltaTime;
            if(mana > maxMana)
            {
                mana = maxMana;
            }
        }
    }

    public override void Die()
    {
        //Player Dies
        deathScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void ChangeMana(float amount)
    {
        counter = 0;
        mana += amount;
    }

    public float RetunManaAmount()
    {
        return mana;
    }

    public void SetMaxMana(float amount)
    {
        maxMana = amount;
        manaBar.transform.localScale = new Vector3(amount / 100, manaBar.transform.localScale.y, manaBar.transform.localScale.z);
        manaBorder.transform.localScale = new Vector3(amount / 100, manaBorder.transform.localScale.y, manaBorder.transform.localScale.z);
    }

    public void SetMaxHealth(float amount)
    {
        maxHealth = amount;
        healthBar.transform.localScale = new Vector3(amount/100, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
        healthBorder.transform.localScale = new Vector3(amount / 100, healthBorder.transform.localScale.y, healthBorder.transform.localScale.z);
    }

    public float ReturnMaxMana()
    {
        return maxMana;
    }
}
