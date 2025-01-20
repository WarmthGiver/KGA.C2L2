using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public sealed class WeaponActiveRotation : WeaponRotation
{
    Vector3 tempMousePosition;

    protected override void Update()
    {
        // �׻� ���콺 Ŀ�� ����
        if (WeaponTypeActive.isSkillOn == true)
        {
            StartCoroutine(FacingTarget(WeaponDirectionVector()));
        }
        // ��ų �����ϴ� ���� ���� ����
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
