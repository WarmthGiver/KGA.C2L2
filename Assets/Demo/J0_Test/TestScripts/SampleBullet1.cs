/* 
 * 작성자: 이재영
 * 수정 날짜: 25/01/13
 * 수정 및 추가 내용: 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleBullet1 : BulletController
{
    [SerializeField] 
    private int _bulletDamage;

    [SerializeField] 
    private float _coolTime;

    private int _killCount;

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

    public int KillCount
    {
        get { return _killCount; }
        set { _killCount = value; }
    }
    
    private void Start()
    {
        BulletDamage = 8;
        CoolTime = 0.3f;
        KillCount = 0;
    }   
}
