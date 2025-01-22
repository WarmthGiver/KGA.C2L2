using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplosion : Bullet
{
    [SerializeField]
    protected Explosion explosionPrefab;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        // �� ������ ������ �Ͼ�� �����
        if (collision.CompareTag("Enemy"))
        {
            var explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
            explosion.Initialize(damage);
            gameObject.SetActive(false);
        }
    }
}
