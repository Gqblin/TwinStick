using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class LevelUpMenu : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private TextMeshProUGUI soulpoints;
    [SerializeField] private TextMeshProUGUI healthLevel;
    [SerializeField] private TextMeshProUGUI manaLevel;
    [SerializeField] private TextMeshProUGUI strengthLevel;

    private PlayerLevel playerLevel;
    void Start()
    {
        playerLevel = FindObjectOfType<PlayerLevel>();
        menu.SetActive(false);
    }

    public void SetMenuActive()
    {
        menu.SetActive(true);
    }

    public void HideMenu()
    {
        menu.SetActive(false);
    }

    public void UpdateUI()
    {
        soulpoints.text = playerLevel.ReturnSoulPointsAmount().ToString();
        healthLevel.text = "lvl " + playerLevel.ReturnHealthLevel().ToString() + "/" + playerLevel.ReturnMaxHealthLevel().ToString();
        manaLevel.text = "lvl " + playerLevel.ReturnManaLevel().ToString() + "/" + playerLevel.ReturnMaxManaLevel().ToString();
        strengthLevel.text = "lvl " + playerLevel.ReturnStrengthLevel().ToString() + "/" + playerLevel.ReturnMaxStrengthLevel().ToString();
    }
}
