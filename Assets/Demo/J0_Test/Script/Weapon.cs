using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    protected int bulletDamage;

    [SerializeField]
    protected float coolTime;

    [SerializeField]
    protected float bulletSpeed;

    [SerializeField]
    private Transform muzzle;

    [SerializeField]
    protected Bullet bullet;

    protected float tempElapsedTime;


    protected virtual void Update()
    {
        tempElapsedTime -= Time.deltaTime;

        if (tempElapsedTime < 0f)
        {
            FireBullet();

            tempElapsedTime = coolTime;
        }
    }

    public virtual void FireBullet()
    {
        var bullet = Instantiate(this.bullet, muzzle.position, muzzle.rotation);
        bullet.Initialize(bulletDamage, bulletSpeed);
    }
}
