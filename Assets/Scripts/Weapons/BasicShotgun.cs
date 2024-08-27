using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShotgun : Wand
{
    //[SerializeField] private float shellsAmount = 8;
    //[SerializeField] private float bulletSpread = 20f;

    //private void Start()
    //{
    //    weaponType = "SemiAuto";
    //}

    //public override void Shoot()
    //{
    //    if (!reloading)
    //    {
    //        if (ammo > 0)
    //        {
    //            if (cooldownOver)
    //            {
    //                for (int i = 0; i < shellsAmount; i++)
    //                {
    //                    Quaternion direction = player.transform.localRotation;
    //                    direction.y += Random.Range(-bulletSpread, bulletSpread);
    //                    GameObject gvd = Instantiate(projectile, transform.position, transform.rotation);
    //                    gvd.transform.Rotate(0, Random.Range(-bulletSpread, bulletSpread), 0);
    //                }
    //                ammo -= 1;
    //                StartCoroutine("ShootCooldown");
    //            }
    //        }
    //    }
    //    ammoIndicator.UpdateAmmo(ammo, clipsAmount * maxAmmo + extraAmmo);
    //}
}
