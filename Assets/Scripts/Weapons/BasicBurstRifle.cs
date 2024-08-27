using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBurstRifle : Wand
{
    //[SerializeField] private float burstBulletsAmount = 0.1f;
    //[SerializeField] private float burstCooldownDuration = 0.5f;
    //private bool burstCooldown;

    //private void Start()
    //{
    //    weaponType = "SemiAuto";
    //}

    //public override void Shoot()
    //{
    //    if (!reloading && !burstCooldown)
    //    {
    //        if (ammo > 0)
    //        {
    //            StartCoroutine("BurstShot");
    //        }
    //    }
    //}


    //IEnumerator BurstShot()
    //{
    //    burstCooldown = true;
    //    for (int i = 0; i < burstBulletsAmount; i++)
    //    {
    //        Instantiate(projectile, transform.position, transform.rotation);
    //        ammo -= 1;
    //        ammoIndicator.UpdateAmmo(ammo, clipsAmount * maxAmmo + extraAmmo);
    //        yield return new WaitForSeconds(shootInterval);
    //    }
    //    yield return new WaitForSeconds(burstCooldownDuration);
    //    burstCooldown = false;
    //}
}
