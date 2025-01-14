/* 
 * 작성자: 이재영
 * 수정 날짜: 25/01/13
 * 수정 및 추가 내용: 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleBullet2 : BulletController
{
    [SerializeField] 
    private int _bulletDamage;

    [SerializeField] 
    private float _coolTime;

    public int BulletDamage
    {
        get { return _bulletDamage; }
        set { _bulletDamage = value; }
    }
    
    public float CoolTime
    {
        get { return _coolTime; }
        set { _coolTime = value; }
    }

    private void Start()
    {
        BulletDamage = 2;
        CoolTime = 0.4f;
    }
}
