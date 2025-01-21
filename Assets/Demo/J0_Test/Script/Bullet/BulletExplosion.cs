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
            gameObject.SetActive(false);
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }
}
