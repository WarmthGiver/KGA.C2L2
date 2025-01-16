using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponTypeB : Weapon
{
    [SerializeField]
    protected Transform[] muzzleTypeB = new Transform[3];

    public override void FireBullet()
    {
        for(int i = 0; i < muzzleTypeB.Length; i++)
        {
            var bullet = Instantiate(this.bullet, muzzleTypeB[i].position, muzzleTypeB[i].rotation);
            bullet.Initialize(bulletDamage, bulletSpeed);
        }
    }
}
