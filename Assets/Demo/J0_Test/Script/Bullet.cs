using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZL.Unity;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    protected Rigidbody2D bulletRigid;

    protected int damage;
    protected float speed;

    protected virtual void Update()
    {
        BulletMovement();
        // 범위 밖 나가면 지우기
        DestroyBullet();
    }

    protected virtual void BulletMovement()
    {
        bulletRigid.AddForce(transform.up.normalized * speed * 5, ForceMode2D.Impulse);
    }

    public void Initialize(int damage, float speed)
    {
        this.damage = damage;
        this.speed = speed;
    }
    public void DestroyBullet()
    {
        if (transform.position.x < -10f || transform.position.x > 10f || transform.position.y < -10f || transform.position.y > 10f)
        {
            gameObject.SetActive(false);
        }
    }
}
