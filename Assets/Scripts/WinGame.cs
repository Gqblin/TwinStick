using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{

    [SerializeField] private GameObject winScreen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") /*&& enemies.Count == 0*/)
        {
            winScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
