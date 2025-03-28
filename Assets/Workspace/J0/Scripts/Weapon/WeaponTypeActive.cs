﻿using ArmadaInvencible.ZL;

using System.Collections;

using UnityEngine;

namespace ArmadaInvencible.J0
{
    public sealed class WeaponTypeActive : Weapon
    {
        public static bool isSkillOn = false;

        protected override void Update()
        {
            tempElapsedTime -= Time.deltaTime;

            if (tempElapsedTime < 0f && isSkillOn == false)
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

        private IEnumerator ActiveSkillPattern()
        {
            for (int i = pullTriggerCount; i > 0; i--)
            {
                var bullet = bulletPool.Generate();

                bullet.transform.rotation = gameObject.transform.rotation;

                bullet.transform.position = gameObject.transform.position;

                bullet.Initialize(bulletDamage, bulletSpeed);

                bullet.gameObject.SetActive(true);

                var sfx = SFXPoolManager.Instance.Generate(sfxName);

                sfx.transform.position = transform.position;

                sfx.gameObject.SetActive(true);

                yield return new WaitForSeconds(term);
            }
        }

        private IEnumerator CoolTime()
        {
            for (float i = coolTime; i > 0; i--)
            {
                yield return new WaitForSeconds(1f);
            }

            tempElapsedTime = coolTime;

            isSkillOn = false;
        }
    }
}