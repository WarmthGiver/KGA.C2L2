using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplosion : Bullet
{
    [SerializeField]
    protected GameObject explosion;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        // �� ������ ������ �Ͼ�� �����
        if (collision.CompareTag("Enemy"))
        {
            Instantiate(explosion, transform.position, transform.rotation);
            collision.GetComponent<IDamageable>()?.GetDamage(damage);
            gameObject.SetActive(false);
        }
    }
}
