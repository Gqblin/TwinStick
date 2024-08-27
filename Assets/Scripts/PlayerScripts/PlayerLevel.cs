using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    //amount of xp needed for every level
    [SerializeField] private float[] xpNeededPerLevel = new float[] { 100f, 300f, 750f, 1350, 2000f };

    [SerializeField] private float[] damageMultiplierOnLevel = new float[] { 1.1f, 1.2f, 1.3f, 1.45f, 1.65f };
    [SerializeField] private float[] healthOnEveryLevel = new float[] { 115f, 130f, 145f, 160f, 175f };
    [SerializeField] private float[] manaOnEveryLevel = new float[] { 115f, 130f, 145f, 160f, 175f };

    private LevelUpMenu levelMenu;
    private PlayerHealth playerhealth;
    private Wand wand;

    public int level;
    private int maxLevel;
    private float exp;
    private int levelUpPoints;

    public int strengthLevel;
    public int healthLevel;
    public int manaLevel;

    //private float damageMultiplier = 1f;
    void Start()
    {
        level = 1;
        maxLevel = xpNeededPerLevel.Length;
        playerhealth = FindObjectOfType<PlayerHealth>();
        levelMenu = FindObjectOfType<LevelUpMenu>();
        wand = FindObjectOfType<Wand>();
    }

    private void Update()
    {
        //if(levelUpPoints > 0)
        //{
        //    if (Input.GetKeyDown(KeyCode.G))
        //    {
        //        strengthLevel++;
        //        levelUpPoints--;
        //    }
        //    if (Input.GetKeyDown(KeyCode.H))
        //    {
        //        healthLevel++;
        //        levelUpPoints--;
        //    }
        //    if (Input.GetKeyDown(KeyCode.J))
        //    {
        //        manaLevel++;
        //        levelUpPoints--;    
        //    }
        //}
    }

    public void ReciveExp(float amount)
    {
        exp += amount;
        CheckLevel();
    }

    private void CheckLevel()
    {

        for(int i = level; i < maxLevel; i++)
        {
            if(exp >= xpNeededPerLevel[i - 1])
            {
                LevelUp();
            }
        }

    }

    private void LevelUp()
    {
        level++;
        levelUpPoints += 2;
        levelMenu.SetMenuActive();
        levelMenu.UpdateUI();
    }

    public void ChangeWand(GameObject newWand)
    {
        wand = newWand.GetComponent<Wand>();
        if(strengthLevel > 0)
        {
            wand.MultiplyDamage(damageMultiplierOnLevel[strengthLevel - 1]);
        }
        
    }

    private void UpdateStats()
    {
        if(strengthLevel > 0)
        {
            wand.MultiplyDamage(damageMultiplierOnLevel[strengthLevel - 1]);
        }
        if(healthLevel > 0)
        {
            playerhealth.SetMaxHealth(healthOnEveryLevel[healthLevel - 1]);
        }
        if(manaLevel > 0)
        {
            playerhealth.SetMaxMana(manaOnEveryLevel[manaLevel - 1]);
        }
                
        
    }

    public void UpgradeHealth()
    {
        if(levelUpPoints > 0)
        {
            healthLevel++;
            levelUpPoints--;
            UpdateStats();
            if (levelUpPoints > 0)
            {
                levelMenu.UpdateUI();
            }
            else
            {
                levelMenu.HideMenu();
            }  
        }  
    }

    public void UpgradeMana()
    {
        if(levelUpPoints > 0)
        {
            manaLevel++;
            levelUpPoints--;
            UpdateStats();
            if (levelUpPoints > 0)
            {
                levelMenu.UpdateUI();
            }
            else
            {
                levelMenu.HideMenu();
            }
        }
    }

    public void UpgradeStrength()
    {
        if(levelUpPoints > 0)
        {
            strengthLevel++;
            levelUpPoints--;
            UpdateStats();
            if (levelUpPoints > 0)
            {
                levelMenu.UpdateUI();
            }
            else
            {
                levelMenu.HideMenu();
            }
        } 
    }

    public int ReturnSoulPointsAmount()
    {
        return levelUpPoints;
    }

    public int ReturnHealthLevel()
    {
        return healthLevel;
    }

    public int ReturnManaLevel()
    {
        return manaLevel;
    }

    public int ReturnStrengthLevel()
    {
        return strengthLevel;
    }

    public int ReturnMaxHealthLevel()
    {
        return healthOnEveryLevel.Length;
    }

    public int ReturnMaxManaLevel()
    {
        return manaOnEveryLevel.Length;
    }

    public int ReturnMaxStrengthLevel()
    {
        return damageMultiplierOnLevel.Length;
    }
}
