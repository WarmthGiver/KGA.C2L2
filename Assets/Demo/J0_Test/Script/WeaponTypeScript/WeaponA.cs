using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class WeaponA : Weapon
{
    void Start()
    {
        // �ӽ� ��(�������� ����)
        damage = 2;
        speed = 0.3f;
    }
}
