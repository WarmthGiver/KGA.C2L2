using ArmadaInvencible;

using System.Collections;

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

                bullet.gameObject.SetActive(true);

                var sfx = SFXPoolManager.Instance.Generate(sfxName);

                sfx.transform.position = transform.position;

                sfx.gameObject.SetActive(true);
            }

            yield return new WaitForSeconds(term);
        }
    }
}
