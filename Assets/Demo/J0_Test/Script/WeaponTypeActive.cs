using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class WeaponTypeActive : Weapon
{
    private bool isSkillOn = false;

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
        tempVector = (muzzle.position - center).normalized;

        tempAngle = muzzle.rotation;

        StartCoroutine(ActiveSkill(tempVector, tempAngle));
    }

    IEnumerator ActiveSkill(Vector3 shootDirection, Quaternion shootAngle)
    {
        for (int i = 8; i > 0; i--)
        {
            var bullet = Instantiate(this.bullet, shootDirection, shootAngle);
            bullet.Initialize(bulletDamage, bulletSpeed);
            yield return new WaitForSeconds(0.25f);
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
