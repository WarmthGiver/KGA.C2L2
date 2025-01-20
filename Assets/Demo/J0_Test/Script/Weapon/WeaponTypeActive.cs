using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using ZL.Unity.ObjectPooling;

public sealed class WeaponTypeActive : Weapon
{
    public static bool isSkillOn = false;

    Vector3 center = new Vector3(0, 0, 0);

    Vector3 tempVector;

    Quaternion tempAngle;

    protected override void Update()
    {
        tempElapsedTime -= Time.deltaTime;

        if(tempElapsedTime < 0f && isSkillOn == false)
        {
            // 스페이스 누를 때 실행
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isSkillOn = true;
                FireBullet();
                StartCoroutine(CoolTime());
            }
        }
    }
    
    protected override void FireBullet()
    {
        StartCoroutine(ActiveSkillPattern());
    }

    IEnumerator ActiveSkillPattern()
    {
        for (int i = pullTriggerCount; i > 0; i--)
        {
            var bullet = bulletPool.Generate();
            bullet.transform.rotation = gameObject.transform.rotation;
            bullet.transform.position = gameObject.transform.position;
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
        isSkillOn = false;
    }
}
