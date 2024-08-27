using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class SpellInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI basicSpell;
    [SerializeField] private TextMeshProUGUI specialSpell;

    private string basicSpellInfo;
    private string specialSpellInfo;

    void Start()
    {
        basicSpellInfo = "";
        specialSpellInfo = "";
        UpdateUI();
    }

    public void UpdateSpellInfo(Wand wand)
    {
        basicSpellInfo = wand.ReturnBasicSpellInfo();
        specialSpellInfo = wand.ReturnSpecialSpellInfo();
        UpdateUI();
    }

    private void UpdateUI()
    {
        basicSpell.text = basicSpellInfo;
        specialSpell.text = specialSpellInfo;
    }

    void Update()
    {
        
    }
}
