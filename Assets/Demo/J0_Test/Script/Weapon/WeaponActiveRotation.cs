using System.Collections;

using UnityEngine;

public sealed class WeaponActiveRotation : WeaponRotation
{
    protected override void Update()
    {
        if (WeaponTypeActive.isSkillOn == true)
        {
            StartCoroutine(FacingTarget(WeaponDirectionVector()));
        }

        else
        {
            FacingCursur();
        }
    }

    private IEnumerator FacingTarget(Vector3 lookAt)
    {
        while (WeaponTypeActive.isSkillOn == true)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, AngleCalculator(lookAt));

            yield return null;
        }
    }
}