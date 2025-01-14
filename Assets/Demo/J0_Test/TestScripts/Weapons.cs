/* 
 * 작성자: 이재영
 * 수정 날짜: 25/01/13
 * 수정 및 추가 내용: 
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
