using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplosion : Bullet
{
    [SerializeField]
    protected Explosion explosionPrefab;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        // 적 닿으면 폭발이 일어나고 사라짐
        if (collision.CompareTag("Enemy"))
        {
            var explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
            explosion.Initialize(damage);
            gameObject.SetActive(false);
        }
    }
}
