using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    [SerializeField]
    private Transform[] slots = new Transform[5];

    // EquipWeapon 함수 확인용
    [SerializeField]
    private Weapon[] weapons = new Weapon[5];

    private float equipTime;

    private void Start()
    {
        equipTime = 30f;
        StartCoroutine(EquipWeapon(weapons));
    }
    private IEnumerator EquipWeapon(Weapon[] weapon)
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(weapon[i], slots[i], false);
            Debug.Log($"{i + 1}번째 생성");
            yield return new WaitForSeconds(equipTime);
        }
    }
}
