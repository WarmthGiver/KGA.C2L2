using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public sealed class WeaponActiveRotation : WeaponRotation
{
    Vector3 tempMousePosition;

    protected override void Update()
    {
        // 항상 마우스 커서 향함
        if (WeaponTypeActive.isSkillOn == true)
        {
            StartCoroutine(FacingTarget(WeaponDirectionVector()));
        }
        // 스킬 지속하는 동안 방향 고정
        else
        {
            FacingCursur();
        }
    }

    IEnumerator FacingTarget(Vector3 lookAt)
    {
        while (WeaponTypeActive.isSkillOn == true)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, AngleCalculator(lookAt));
            yield return null;
        }
    }
}
