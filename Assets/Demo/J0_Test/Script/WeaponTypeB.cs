using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponTypeB : Weapon
{
    [SerializeField]
    private Transform[] muzzleTypeB = new Transform[3];

    protected override void FireBullet()
    {
        for(int i = 0; i < muzzleTypeB.Length; i++)
        {
            //var bullet = Instantiate(this.bullet, muzzleTypeB[i].position, muzzleTypeB[i].rotation);
            var bullet = bulletPool.Generate();
            bullet.transform.rotation = muzzleTypeB[i].rotation;
            bullet.transform.position = muzzleTypeB[i].position;
            bullet.Initialize(bulletDamage, bulletSpeed);
            
            //bullet.Initialize(bulletDamage, bulletSpeed);

            /*
            var bullet = bulletPool.Generate();
            bullet.transform.position = muzzle.position;
            bullet.Initialize(bulletDamage, bulletSpeed);
            */
        }
    }
}
