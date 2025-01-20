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

    [SerializeField]
    protected float term;

    protected bool isFireOn = false;

    [SerializeField]
    protected int pullTriggerCount;

    protected float tempElapsedTime = 0;

    protected void Awake()
    {
        tempElapsedTime = coolTime;
    }

    protected virtual void Update()
    {
        tempElapsedTime -= Time.deltaTime;

        if (tempElapsedTime < 0f && isFireOn == false)
        {
            isFireOn = true;
            FireBullet();
            StartCoroutine(CoolTime());
            tempElapsedTime = coolTime;
        }
    }

    protected virtual void FireBullet()
    {
        StartCoroutine(FirePattern());
    }

    protected virtual IEnumerator FirePattern()
    {
        for (int i = pullTriggerCount; i > 0; i--)
        {
            var bullet = bulletPool.Generate();
            gameObject.SetActive(true);
            bullet.transform.rotation = muzzle.rotation;
            bullet.transform.position = muzzle.position;
            bullet.Initialize(bulletDamage, bulletSpeed);
            yield return new WaitForSeconds(term);
        }
    }
    IEnumerator CoolTime()
    {
        for (float i = coolTime; i > 0; i--)
        {
            yield return new WaitForSeconds(1f);
        }
        tempElapsedTime = coolTime;
        isFireOn = false;
    }
}
