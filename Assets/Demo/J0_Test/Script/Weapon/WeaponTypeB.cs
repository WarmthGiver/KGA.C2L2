using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponTypeB : Weapon
{
    [SerializeField]
    private Transform[] muzzleTypeB = new Transform[2];

    protected override IEnumerator FirePattern()
    {
        for (int i = pullTriggerCount; i > 0; i--)
        {
            for (int j = 0; j < muzzleTypeB.Length; j++)
            {
                var bullet = bulletPool.Generate();
                bullet.transform.rotation = muzzleTypeB[j].rotation;
                bullet.transform.position = muzzleTypeB[j].position;
                bullet.Initialize(bulletDamage, bulletSpeed);
            }
                yield return new WaitForSeconds(term);
        }
    }
}
