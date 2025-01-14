/* 
 * �ۼ���: ���翵
 * ���� ��¥: 25/01/13
 * ���� �� �߰� ����: 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons<T> : MonoBehaviour
    where T : BulletController
{
    [SerializeField] private T sampleBullet;

    [SerializeField] private int _bulletDamage;
    [SerializeField] private float _coolTime;
}
