using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealParticles : Bullet
{
    private Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }
    protected override void FixedUpdate()
    {
        
    }

    private void Update()
    {
        transform.position = player.transform.position;
    }
}
