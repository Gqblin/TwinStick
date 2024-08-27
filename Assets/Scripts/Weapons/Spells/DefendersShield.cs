using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendersShield : MonoBehaviour
{
    private Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        
    }

    private void Update()
    {
        transform.position = player.transform.position;
    }
}
