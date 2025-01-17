using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZL.Unity.ObjectPooling;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    protected int bulletDamage;

    [SerializeField]
    protected float coolTime;

    [SerializeField]
    protected float bulletSpeed;

    [SerializeField]
    protected Transform muzzle;

    [SerializeField]
    protected GameObjectPool<Bullet> bulletPool;

    protected float tempElapsedTime = 0;


    protected virtual void Update()
    {
        tempElapsedTime -= Time.deltaTime;

        if (tempElapsedTime < 0f)
        {
            FireBullet();

            tempElapsedTime = coolTime;
        }
    }

    protected virtual void FireBullet()
    {
        var bullet = bulletPool.Generate();
        gameObject.SetActive(true);
        bullet.transform.rotation = muzzle.rotation;
        bullet.transform.position = muzzle.position;
        bullet.Initialize(bulletDamage, bulletSpeed);
    }
}
