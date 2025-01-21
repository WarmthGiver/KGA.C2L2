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

    bool isPlaceable;

    static int slotNumber = 0;

    private void Start()
    {
        isPlaceable = true;
    }

    private void Update()
    {
        CheckPlaceable();

        if (isPlaceable == true)
        {
            EquipWeapon(weapons[slotNumber]);
        }
    }
    private void EquipWeapon(Weapon weapon)
    {
        if (this.weapons[slotNumber] != null)
        {
            Instantiate(weapon, slots[slotNumber], false);
            slotNumber++;
        }
    }
    void CheckPlaceable()
    {
        if (slotNumber >= 5)
        {
            isPlaceable = false;
        }
    }
}
