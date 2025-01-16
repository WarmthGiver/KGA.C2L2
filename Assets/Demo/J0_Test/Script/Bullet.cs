using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D bulletRigid;

    private int damage;
    private float speed;

    void Start()
    {
        
    }

    void Update()
    {
        bulletRigid.AddForce(transform.up.normalized * speed, ForceMode2D.Impulse);

        // 범위 밖 나가면 지우기
        DestroyBullet();
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
            Destroy(gameObject);
        }
    }
}
