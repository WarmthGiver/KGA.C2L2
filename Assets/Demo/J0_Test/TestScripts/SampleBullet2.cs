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

    [SerializeField]
    Rigidbody2D bulletRigid;

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

    private void Update()
    {
        // Bullet 이동
        bulletRigid.AddForce(transform.up.normalized * 2f, ForceMode2D.Impulse);

        if (transform.position.x < -20f || transform.position.x > 20f || transform.position.y < -20f || transform.position.y > 20f)
        {
            Destroy(gameObject);
        }
    }
}
