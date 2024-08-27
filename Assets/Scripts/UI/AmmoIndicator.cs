using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class AmmoIndicator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshPro;

    private float ammoInClip;
    private float ammoInpocket;

    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateAmmo(float clipAmmo, float reserveAmmo)
    {
        ammoInClip = clipAmmo;
        ammoInpocket = reserveAmmo;
        UpdateUI();
    }

    private void UpdateUI()
    {
        textMeshPro.text = ammoInClip.ToString() + "/" + ammoInpocket.ToString();
    }

}
